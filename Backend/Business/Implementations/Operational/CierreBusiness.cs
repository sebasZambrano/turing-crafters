using iTextSharp.text;
using iTextSharp.text.pdf;
using AutoMapper;
using Business.Interfaces;
using Business.Interfaces.Operational;
using Data.Interfaces;
using Data.Interfaces.Operational;
using Data.Interfaces.Parameter;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Dtos.Parameter;
using Entity.Models.Operational;
using Entity.Models.Parameter;

namespace Business.Implementations.Operational
{
    public class CierreBusiness : BaseModelBusiness<Cierre, CierreDto>, ICierreBusiness
    {
        private readonly ICierreData _data;
        private readonly IFacturaDetallePagoData _dataFacturasDetallesPagos;
        private readonly IFacturaData _dataFacturas;
        private readonly INotaCreditoData _dataNotaCredito;
        private readonly ICostoData _dataCostos;
        private readonly IArchivoData _dataArchivos;
        private readonly IEstadoData _dataEstados;
        private readonly IEmpleadoData _dataEmpleado;
        private readonly ICajaData _dataCaja;
        private readonly IBaseModelData<MedioPago, MedioPagoDto> _dataMediosPagos;
        private readonly IBaseModelBusiness<CierreMedioPago, CierreMedioPagoDto> _businessCierresMediosPagos;
        private readonly IMapper _mapper;

        public CierreBusiness(ICierreData data,
            IFacturaDetallePagoData dataFacturasDetallesPagos,
            IFacturaData dataFacturas,
            ICostoData dataCostos,
            IArchivoData dataArchivos,
            IEstadoData dataEstados,
            IEmpleadoData dataEmpleado,
            ICajaData dataCaja,
            IBaseModelData<MedioPago, MedioPagoDto> dataMediosPagos,
            INotaCreditoData dataNotaCredito,
            IBaseModelBusiness<CierreMedioPago, CierreMedioPagoDto> businessCierresMediosPagos,
            IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _dataFacturasDetallesPagos = dataFacturasDetallesPagos;
            _dataFacturas = dataFacturas;
            _dataCostos = dataCostos;
            _dataArchivos = dataArchivos;
            _dataEstados = dataEstados;
            _dataEmpleado = dataEmpleado;
            _dataMediosPagos = dataMediosPagos;
            _dataCaja = dataCaja;
            _dataNotaCredito = dataNotaCredito;
            _businessCierresMediosPagos = businessCierresMediosPagos;
            _mapper = mapper;
        }

        public override async Task<CierreDto> Save(CierreDto dto)
        {
            Estado estadoFacturada = await _dataEstados.GetByCode("FACTURADA");
            List<FacturaDto> facturas = new List<FacturaDto>();
            IEnumerable<CostoDto> costos = new List<CostoDto>();

            if (dto.CajaId != 0)
            {
                //Cierre por caja
                IEnumerable<EmpleadoDto> empleado = await _dataEmpleado.GetDataTable(new QueryFilterDto() { ForeignKey = dto.CajaId, NameForeignKey = "CajaId" });
                facturas = (List<FacturaDto>)await _dataFacturas.GetByDateCaja(dto.FechaInicial, dto.FechaFinal, dto.CajaId);
                costos = await _dataCostos.GetByDateCaja(dto.FechaInicial, dto.FechaFinal, 1, dto.CajaId);
            }
            else
            {
                //Cierre general
                facturas = (List<FacturaDto>)await _dataFacturas.GetByDate(dto.FechaInicial, dto.FechaFinal);
                costos = await _dataCostos.GetByDate(dto.FechaInicial, dto.FechaFinal, 1);
            }

            facturas = facturas.FindAll(i => i.EstadoId == estadoFacturada.Id);


            dto.TotalIngreso = facturas.Sum(i => i.Total);
            dto.TotalEgreso = costos.Sum(i => i.Valor);
            dto.SaldoCaja = dto.TotalIngreso - dto.TotalEgreso;
            dto.CreateAt = DateTime.UtcNow.AddHours(-5);

            Cierre cierre = _mapper.Map<Cierre>(dto);

            cierre = await _data.Save(cierre);

            IEnumerable<CierreMedioPagoDto> cierresMediosPagos = await this.SaveMediosPagos(cierre, facturas, costos);

            Archivo archivo = await GenerarCierre(cierre, cierresMediosPagos, dto.CajaId);

            //Actualizo el saldo en efectivo del cierre
            decimal totalIngresoEfectivo = 0;

            var gruposMedioPagoVentas = cierresMediosPagos.Where(c => !c.Gasto).GroupBy(c => c.MedioPagoId).Select(grupo => new
            {
                MedioPagoId = grupo.Key,
                Total = grupo.Sum(c => c.Total)
            }).ToList();

            foreach (var cierreMedioPago in gruposMedioPagoVentas)
            {
                MedioPago medioPago = await _dataMediosPagos.GetById(cierreMedioPago.MedioPagoId);

                if (medioPago.Codigo == "EFECTIVO")
                {
                    totalIngresoEfectivo += cierreMedioPago.Total;
                }
            }

            cierre.SaldoCaja = totalIngresoEfectivo;
            await _data.Update(cierre);
            return _mapper.Map<CierreDto>(cierre);

        }

        public async Task<IEnumerable<CierreMedioPagoDto>> SaveMediosPagos(Cierre cierre, List<FacturaDto> facturas, IEnumerable<CostoDto> costos)
        {
            foreach (var factura in facturas)
            {
                IEnumerable<FacturaDetallePagoDto> facturaDetallesPagos = await _dataFacturasDetallesPagos.GetDataTable(new QueryFilterDto { ForeignKey = factura.Id, NameForeignKey = "FacturaId" });

                foreach (var facturaDetallePago in facturaDetallesPagos)
                {
                    CierreMedioPagoDto cierreMedioPago = new CierreMedioPagoDto()
                    {
                        Total = facturaDetallePago.Valor,
                        Gasto = false,
                        CierreId = cierre.Id,
                        MedioPagoId = facturaDetallePago.MedioPagoId
                    };

                    await _businessCierresMediosPagos.Save(cierreMedioPago);
                }
            }

            foreach (var costo in costos)
            {
                MedioPago medioPago = await _dataMediosPagos.GetByCode("EFECTIVO");

                CierreMedioPagoDto cierreMedioPago = new CierreMedioPagoDto()
                {
                    Total = costo.Valor,
                    Gasto = true,
                    CierreId = cierre.Id,
                    MedioPagoId = medioPago.Id
                };

                await _businessCierresMediosPagos.Save(cierreMedioPago);
            }

            IEnumerable<CierreMedioPagoDto> cierresMediosPagos = await _businessCierresMediosPagos.GetDataTable(new QueryFilterDto { ForeignKey = cierre.Id, NameForeignKey = "CierreId" });

            return cierresMediosPagos;
        }

        public async Task<Archivo> GenerarCierre(Cierre cierre, IEnumerable<CierreMedioPagoDto> cierresMediosPagos, int CajaId)
        {
            Archivo archivo = new Archivo();

            IEnumerable<CierreDto> cierreCompleto = await _data.GetDataTable(new QueryFilterDto() { ForeignKey = cierre.Id, NameForeignKey = "Id" });

            using (MemoryStream memoryStream = new MemoryStream())
            {
                Rectangle envelope = new Rectangle(200, 3500);
                Document document = new Document(envelope);

                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                writer.CloseStream = false;

                await ModificaPdf(document, cierreCompleto.First(), cierresMediosPagos, CajaId);
                document.Close();

                byte[]
                pdfBytes = memoryStream.ToArray();

                string base64Content = Convert.ToBase64String(pdfBytes);

                archivo = new Archivo()
                {
                    Nombre = "Cierre",
                    Tabla = "Cierres",
                    TablaId = cierre.Id,
                    Extension = "pdf",
                    Content = base64Content,
                    CreateAt = DateTime.UtcNow.AddHours(-5)
                };

                await _dataArchivos.Save(archivo);
            }

            return archivo;
        }

        private async Task ModificaPdf(Document doc, CierreDto cierre, IEnumerable<CierreMedioPagoDto> cierresMediosPagos, int CajaId)
        {
            var tituloCierre = "";
            if (CajaId == 0)
            {
                tituloCierre = "CIERRE GENERAL";
            }
            else
            {
                Caja caja = await _dataCaja.GetById(CajaId);
                tituloCierre = $"CIERRE {caja.Nombre}";
            }

            doc.SetMargins(15f, -30f, 0f, 10f);
            doc.Open();

            Font titledFont = new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD, BaseColor.BLACK);
            Font standardFont = new Font(Font.FontFamily.HELVETICA, 9, Font.NORMAL, BaseColor.BLACK);
            PdfPCell celLineas = new PdfPCell(new Phrase("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", standardFont));
            celLineas.BorderWidth = 0;

            Estado estadoAprobada = await _dataEstados.GetByCode("NC-2");
            decimal totalNotasCreditoEfectivo = 0;

            IEnumerable<NotaCreditoDto> notasCreditos = await _dataNotaCredito.GetByDate(cierre.FechaInicial, cierre.FechaFinal, estadoAprobada.Id);

            var gruposMedioPagoNotasCredito = notasCreditos.GroupBy(c => c.MedioPagoId).Select(grupo => new
            {
                MedioPagoId = grupo.Key,
                Total = grupo.Sum(c => c.Total)
            }).ToList();

            PdfPTable tblHeader = new PdfPTable(1);
            tblHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            tblHeader.DefaultCell.Border = Rectangle.NO_BORDER;
            float[] widths = new float[] { 70f };
            tblHeader.SetWidths(widths);

            PdfPCell cellEspacio = new PdfPCell(new Phrase("\n", titledFont));
            cellEspacio.BorderWidth = 0;

            PdfPCell clheader = new PdfPCell(new Phrase($"{tituloCierre}", titledFont));
            clheader.BorderWidth = 0;
            clheader.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell clEmpleado = new PdfPCell(new Phrase($"EMPLEADO(A): {cierre.Empleado}", titledFont));
            clEmpleado.BorderWidth = 0;
            clEmpleado.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell clInicio = new PdfPCell(new Phrase($"INICIO: {cierre.FechaInicial}", titledFont));
            clInicio.BorderWidth = 0;
            clInicio.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell clFin = new PdfPCell(new Phrase($"FIN: {cierre.FechaFinal}", titledFont));
            clFin.BorderWidth = 0;
            clFin.HorizontalAlignment = Element.ALIGN_CENTER;

            tblHeader.AddCell(clheader);
            tblHeader.AddCell(clEmpleado);
            tblHeader.AddCell(clInicio);
            tblHeader.AddCell(clFin);
            tblHeader.AddCell(celLineas);

            PdfPTable tblBody = new PdfPTable(2);
            tblBody.HorizontalAlignment = Element.ALIGN_CENTER;
            tblBody.DefaultCell.Border = Rectangle.NO_BORDER;
            float[] widthstblBody = new float[] { 60f, 40f };
            tblBody.SetWidths(widthstblBody);

            PdfPCell clVentas = new PdfPCell(new Phrase("VENTAS", titledFont));
            clVentas.BorderWidth = 0;
            clVentas.HorizontalAlignment = Element.ALIGN_CENTER;

            clVentas.Colspan = 2;
            tblBody.AddCell(clVentas);

            var gruposMedioPagoVentas = cierresMediosPagos.Where(c => !c.Gasto).GroupBy(c => c.MedioPagoId).Select(grupo => new
            {
                MedioPagoId = grupo.Key,
                Total = grupo.Sum(c => c.Total)
            }).ToList();

            decimal totalIngresoEfectivo = 0;

            // Verificar si hay elementos en la lista de notas de crédito
            if (gruposMedioPagoNotasCredito.Any())
            {
                foreach (var nota in gruposMedioPagoNotasCredito)
                {
                    //Mostrar las ventas por medio de pago
                    foreach (var cierreMedioPago in gruposMedioPagoVentas)
                    {
                        MedioPago medioPago = await _dataMediosPagos.GetById(cierreMedioPago.MedioPagoId);

                        var totalMedioPago = cierreMedioPago.Total;

                        // Restar las notas de crédito de las ventas por medio de pago
                        if (nota.MedioPagoId == cierreMedioPago.MedioPagoId)
                        {
                            totalMedioPago -= nota.Total;
                        }

                        PdfPCell clMediosPagosIngresos = new PdfPCell(new Phrase($"{medioPago.Nombre.ToUpper()}:", titledFont));
                        clMediosPagosIngresos.BorderWidth = 0;
                        clMediosPagosIngresos.HorizontalAlignment = Element.ALIGN_LEFT;

                        PdfPCell clMediosPagosIngresosData = new PdfPCell(new Phrase(string.Format("{0:C0}", totalMedioPago), titledFont));
                        clMediosPagosIngresosData.BorderWidth = 0;
                        clMediosPagosIngresosData.HorizontalAlignment = Element.ALIGN_RIGHT;

                        if (medioPago.Codigo == "EFECTIVO")
                        {
                            totalIngresoEfectivo += cierreMedioPago.Total;
                        }

                        tblBody.AddCell(clMediosPagosIngresos);
                        tblBody.AddCell(clMediosPagosIngresosData);
                    }
                }
            }
            else
            {
                //Mostrar las ventas por medio de pago
                foreach (var cierreMedioPago in gruposMedioPagoVentas)
                {
                    MedioPago medioPago = await _dataMediosPagos.GetById(cierreMedioPago.MedioPagoId);

                    var totalMedioPago = cierreMedioPago.Total;

                    PdfPCell clMediosPagosIngresos = new PdfPCell(new Phrase($"{medioPago.Nombre.ToUpper()}:", titledFont));
                    clMediosPagosIngresos.BorderWidth = 0;
                    clMediosPagosIngresos.HorizontalAlignment = Element.ALIGN_LEFT;

                    PdfPCell clMediosPagosIngresosData = new PdfPCell(new Phrase(string.Format("{0:C0}", totalMedioPago), titledFont));
                    clMediosPagosIngresosData.BorderWidth = 0;
                    clMediosPagosIngresosData.HorizontalAlignment = Element.ALIGN_RIGHT;

                    if (medioPago.Codigo == "EFECTIVO")
                    {
                        totalIngresoEfectivo += cierreMedioPago.Total;
                    }

                    tblBody.AddCell(clMediosPagosIngresos);
                    tblBody.AddCell(clMediosPagosIngresosData);
                }
            }

            PdfPCell cltotalVentas = new PdfPCell(new Phrase("TOTAL:", titledFont));
            cltotalVentas.BorderWidth = 0;
            cltotalVentas.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPCell cltotalVentasData = new PdfPCell(new Phrase(string.Format("{0:C0}", cierre.TotalIngreso - notasCreditos.Sum(i => i.Total)), titledFont));
            cltotalVentasData.BorderWidth = 0;
            cltotalVentasData.HorizontalAlignment = Element.ALIGN_RIGHT;

            tblBody.AddCell(cltotalVentas);
            tblBody.AddCell(cltotalVentasData);
            celLineas.Colspan = 2;
            tblBody.AddCell(celLineas);

            PdfPCell clGastos = new PdfPCell(new Phrase("GASTOS", titledFont));
            clGastos.BorderWidth = 0;
            clGastos.HorizontalAlignment = Element.ALIGN_CENTER;

            clGastos.Colspan = 2;
            tblBody.AddCell(clGastos);

            var gruposMedioPagoGastos = cierresMediosPagos.Where(c => c.Gasto).GroupBy(c => c.MedioPagoId).Select(grupo => new
            {
                MedioPagoId = grupo.Key,
                Total = grupo.Sum(c => c.Total)
            }).ToList();

            foreach (var cierreMedioPago in gruposMedioPagoGastos)
            {
                MedioPago medioPago = await _dataMediosPagos.GetById(cierreMedioPago.MedioPagoId);

                PdfPCell clMediosPagosEgresos = new PdfPCell(new Phrase($"{medioPago.Nombre.ToUpper()}:", titledFont));
                clMediosPagosEgresos.BorderWidth = 0;
                clMediosPagosEgresos.HorizontalAlignment = Element.ALIGN_LEFT;

                PdfPCell clMediosPagosEgresosData = new PdfPCell(new Phrase(string.Format("{0:C0}", cierreMedioPago.Total), titledFont));
                clMediosPagosEgresosData.BorderWidth = 0;
                clMediosPagosEgresosData.HorizontalAlignment = Element.ALIGN_RIGHT;

                tblBody.AddCell(clMediosPagosEgresos);
                tblBody.AddCell(clMediosPagosEgresosData);
            }

            PdfPCell clTotalGastos = new PdfPCell(new Phrase("TOTAL:", titledFont));
            clTotalGastos.BorderWidth = 0;
            clTotalGastos.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPCell clTotalGastosData = new PdfPCell(new Phrase(string.Format("{0:C0}", cierre.TotalEgreso), titledFont));
            clTotalGastosData.BorderWidth = 0;
            clTotalGastosData.HorizontalAlignment = Element.ALIGN_RIGHT;

            tblBody.AddCell(clTotalGastos);
            tblBody.AddCell(clTotalGastosData);
            celLineas.Colspan = 2;
            tblBody.AddCell(celLineas);

            PdfPCell clNotasCreditos = new PdfPCell(new Phrase("NOTAS CRÉDITO", titledFont));
            clNotasCreditos.BorderWidth = 0;
            clNotasCreditos.HorizontalAlignment = Element.ALIGN_CENTER;

            clNotasCreditos.Colspan = 2;
            tblBody.AddCell(clNotasCreditos);

            foreach (var nota in gruposMedioPagoNotasCredito)
            {
                MedioPago medioPago = await _dataMediosPagos.GetById(nota.MedioPagoId);

                if (medioPago.Codigo == "EFECTIVO")
                {
                    totalNotasCreditoEfectivo += nota.Total;
                }

                PdfPCell clMediosPagosNotasCredito = new PdfPCell(new Phrase($"{medioPago.Nombre.ToUpper()}:", titledFont));
                clMediosPagosNotasCredito.BorderWidth = 0;
                clMediosPagosNotasCredito.HorizontalAlignment = Element.ALIGN_LEFT;

                PdfPCell clMediosPagosNotasCreditoData = new PdfPCell(new Phrase(string.Format("{0:C0}", nota.Total), titledFont));
                clMediosPagosNotasCreditoData.BorderWidth = 0;
                clMediosPagosNotasCreditoData.HorizontalAlignment = Element.ALIGN_RIGHT;

                tblBody.AddCell(clMediosPagosNotasCredito);
                tblBody.AddCell(clMediosPagosNotasCreditoData);
            }

            PdfPCell clTotalNotasCredito = new PdfPCell(new Phrase("TOTAL:", titledFont));
            clTotalNotasCredito.BorderWidth = 0;
            clTotalNotasCredito.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPCell clTotalNotasCreditoData = new PdfPCell(new Phrase(string.Format("{0:C0}", notasCreditos.Sum(i => i.Total)), titledFont));
            clTotalNotasCreditoData.BorderWidth = 0;
            clTotalNotasCreditoData.HorizontalAlignment = Element.ALIGN_RIGHT;

            tblBody.AddCell(clTotalNotasCredito);
            tblBody.AddCell(clTotalNotasCreditoData);
            celLineas.Colspan = 2;
            tblBody.AddCell(celLineas);

            //if (facturasAnuladas.Count() > 0)
            //{
            //    PdfPCell clAnuladas = new PdfPCell(new Phrase("FACTURAS ANULADAS:", titledFont));
            //    clAnuladas.BorderWidth = 0;
            //    clAnuladas.HorizontalAlignment = Element.ALIGN_LEFT;

            //    PdfPCell clAnuladasData = new PdfPCell(new Phrase(facturasAnuladas.Count().ToString(), titledFont));
            //    clAnuladasData.BorderWidth = 0;
            //    clAnuladasData.HorizontalAlignment = Element.ALIGN_RIGHT;

            //    tblBody.AddCell(clAnuladas);
            //    tblBody.AddCell(clAnuladasData);

            //    PdfPCell clTotalAnuladas = new PdfPCell(new Phrase("TOTAL ANULADAS:", titledFont));
            //    clTotalAnuladas.BorderWidth = 0;
            //    clTotalAnuladas.HorizontalAlignment = Element.ALIGN_LEFT;

            //    PdfPCell clTotalAnuladasData = new PdfPCell(new Phrase(string.Format("{0:C0}", facturasAnuladas.Sum(i => i.SubTotal)), titledFont));
            //    clTotalAnuladasData.BorderWidth = 0;
            //    clTotalAnuladasData.HorizontalAlignment = Element.ALIGN_RIGHT;

            //    tblBody.AddCell(clTotalAnuladas);
            //    tblBody.AddCell(clTotalAnuladasData);
            //    celLineas.Colspan = 2;
            //    tblBody.AddCell(celLineas);
            //}

            PdfPCell clBase = new PdfPCell(new Phrase("BASE:", titledFont));
            clBase.BorderWidth = 0;
            clBase.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPCell clBaseData = new PdfPCell(new Phrase(string.Format("{0:C0}", cierre.Base), titledFont));
            clBaseData.BorderWidth = 0;
            clBaseData.HorizontalAlignment = Element.ALIGN_RIGHT;

            cellEspacio.Colspan = 2;
            tblBody.AddCell(cellEspacio);

            tblBody.AddCell(clBase);
            tblBody.AddCell(clBaseData);

            PdfPCell clEfectivoCaja = new PdfPCell(new Phrase("EFECTIVO EN CAJA:", titledFont));
            clEfectivoCaja.BorderWidth = 0;
            clEfectivoCaja.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPCell clEfectivoCajaData = new PdfPCell(new Phrase(string.Format("{0:C0}", totalIngresoEfectivo - totalNotasCreditoEfectivo), titledFont));
            clEfectivoCajaData.BorderWidth = 0;
            clEfectivoCajaData.HorizontalAlignment = Element.ALIGN_RIGHT;

            tblBody.AddCell(clEfectivoCaja);
            tblBody.AddCell(clEfectivoCajaData);

            PdfPCell clTotalGastosCierre = new PdfPCell(new Phrase("GASTOS CIERRE:", titledFont));
            clTotalGastosCierre.BorderWidth = 0;
            clTotalGastosCierre.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPCell clTotalGastosCierreData = new PdfPCell(new Phrase($"- {string.Format("{0:C0}", cierre.TotalEgreso)}", titledFont));
            clTotalGastosCierreData.BorderWidth = 0;
            clTotalGastosCierreData.HorizontalAlignment = Element.ALIGN_RIGHT;

            tblBody.AddCell(clTotalGastosCierre);
            tblBody.AddCell(clTotalGastosCierreData);

            PdfPCell clSaldoEfectivo = new PdfPCell(new Phrase("SALDO EFECTIVO:", titledFont));
            clSaldoEfectivo.BorderWidth = 0;
            clSaldoEfectivo.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPCell clSaldoEfectivoData = new PdfPCell(new Phrase($"= {string.Format("{0:C0}", (totalIngresoEfectivo - totalNotasCreditoEfectivo) - cierre.TotalEgreso)}", titledFont));
            clSaldoEfectivoData.BorderWidth = 0;
            clSaldoEfectivoData.HorizontalAlignment = Element.ALIGN_RIGHT;

            tblBody.AddCell(clSaldoEfectivo);
            tblBody.AddCell(clSaldoEfectivoData);
            celLineas.Colspan = 2;
            tblBody.AddCell(celLineas);

            PdfPCell clSaldoEfectivoEmpleado = new PdfPCell(new Phrase("SALDO EMPLEADO:", titledFont));
            clSaldoEfectivoEmpleado.BorderWidth = 0;
            clSaldoEfectivoEmpleado.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPCell clSaldoEfectivoEmpleadoData = new PdfPCell(new Phrase($"{string.Format("{0:C0}", cierre.SaldoEmpleado)}", titledFont));
            clSaldoEfectivoEmpleadoData.BorderWidth = 0;
            clSaldoEfectivoEmpleadoData.HorizontalAlignment = Element.ALIGN_RIGHT;

            tblBody.AddCell(clSaldoEfectivoEmpleado);
            tblBody.AddCell(clSaldoEfectivoEmpleadoData);
            celLineas.Colspan = 2;
            tblBody.AddCell(celLineas);

            PdfPCell clObservacion = new PdfPCell(new Phrase("OBSERVACIÓN:", titledFont));
            clObservacion.BorderWidth = 0;
            clObservacion.HorizontalAlignment = Element.ALIGN_LEFT;

            clObservacion.Colspan = 2;
            tblBody.AddCell(clObservacion);

            PdfPCell clObservacionData = new PdfPCell(new Phrase(cierre.Observacion, titledFont));
            clObservacionData.BorderWidth = 0;
            clObservacionData.HorizontalAlignment = Element.ALIGN_LEFT;

            clObservacionData.Colspan = 2;
            tblBody.AddCell(clObservacionData);


            PdfPTable tblGeneral = new PdfPTable(1);
            tblGeneral.HorizontalAlignment = Element.ALIGN_LEFT;
            tblGeneral.DefaultCell.Border = Rectangle.NO_BORDER;

            tblGeneral.AddCell(tblHeader);
            tblGeneral.AddCell(tblBody);

            doc.Add(tblGeneral);
            doc.Close();
        }

        public async Task<Archivo> GetArchivoById(int id)
        {
            Archivo archivo = await _dataArchivos.GetByTablaId(id, "Cierres");

            return archivo;
        }
    }
}
