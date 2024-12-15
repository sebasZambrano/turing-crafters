using AutoMapper;
using Business.Interfaces.Inventory;
using Business.Interfaces.Operational;
using Data.Interfaces;
using Data.Interfaces.Inventory;
using Data.Interfaces.Operational;
using Data.Interfaces.Parameter;
using Data.Interfaces.Security;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Dtos.Operational;
using Entity.Dtos.Parameter;
using Entity.Models.Inventory;
using Entity.Models.Operational;
using Entity.Models.Parameter;
using Entity.Models.Security;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Business.Implementations.Operational
{
    public class FacturaBusiness : BaseModelBusiness<Factura, FacturaDto>, IFacturaBusiness
    {
        private readonly IFacturaData _data;
        private readonly IEmpleadoData _dataEmpleado;
        private readonly IEmpresaData _dataEmpresa;
        private readonly IEstadoData _dataEstado;
        private readonly IFacturaDetalleData _dataFacturaDetalle;
        private readonly IFacturaDetallePagoData _dataFacturaDetallePago;
        private readonly IPersonaData _dataPersona;
        private readonly IArchivoData _dataArchivo;
        private readonly ICajaData _dataCaja;
        private readonly IInsumoProductoData _dataInsumoProducto;
        private readonly IInventarioDetalleData _dataInventarioDetalle;
        private readonly IBitacoraInventarioData _dataBitacoraInventario;
        private readonly IDetalleInventarioBodegaData _dataDetalleInventarioBodega;
        private readonly IBaseModelData<Cliente, ClienteDto> _dataCliente;
        private readonly INumeracionFacturaData _dataNumeracionFactura;
        private readonly IBitacoraInventarioBusiness _businessBitacoraInventario;
        private readonly IMapper _mapper;

        public FacturaBusiness(
            IFacturaData data,
            INumeracionFacturaData dataNumeracionFactura,
            IEmpleadoData dataEmpleado,
            IEmpresaData dataEmpresa,
            IBaseModelData<Cliente, ClienteDto> dataCliente,
            IEstadoData dataEstado,
            IFacturaDetalleData dataFacturaDetalle,
            IFacturaDetallePagoData dataFacturaDetallePago,
            IPersonaData dataPersona,
            IArchivoData dataArchivo,
            ICajaData dataCaja,
            IInsumoProductoData dataInsumoProducto,
            IInventarioDetalleData dataInventarioDetalle,
            IBitacoraInventarioData dataBitacoraInventario,
            IBitacoraInventarioBusiness businessBitacoraInventario,
            IDetalleInventarioBodegaData dataDetalleInventarioBodega,
            IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _mapper = mapper;
            _dataEstado = dataEstado;
            _dataFacturaDetalle = dataFacturaDetalle;
            _dataFacturaDetallePago = dataFacturaDetallePago;
            _dataArchivo = dataArchivo;
            _dataEmpleado = dataEmpleado;
            _dataEmpresa = dataEmpresa;
            _dataCliente = dataCliente;
            _dataPersona = dataPersona;
            _dataCaja = dataCaja;
            _dataNumeracionFactura = dataNumeracionFactura;
            _dataInsumoProducto = dataInsumoProducto;
            _dataInventarioDetalle = dataInventarioDetalle;
            _dataBitacoraInventario = dataBitacoraInventario;
            _dataDetalleInventarioBodega = dataDetalleInventarioBodega;
            _businessBitacoraInventario = businessBitacoraInventario;
        }

        public override async Task<FacturaDto> Save(FacturaDto dto)
        {
            NumeracionFactura numeracionFactura = new NumeracionFactura();

            if (dto.Remision)
            {
                numeracionFactura = await _dataNumeracionFactura.GetByCode("RM");
            }
            else
            {
                numeracionFactura = await _dataNumeracionFactura.GetByCode("POS");
            }

            numeracionFactura.NumActual = ++numeracionFactura.NumActual;
            numeracionFactura.UpdateAt = DateTime.UtcNow.AddHours(-5);
            await _dataNumeracionFactura.Update(numeracionFactura);

            string codigo = numeracionFactura.Prefijo + "-" + numeracionFactura.NumActual;

            //Consulto el estado
            Estado estado = await _dataEstado.GetByCode("FACTURADA");

            //Consulto el empleado
            Empleado empleado = await _dataEmpleado.GetById(dto.EmpleadoId);

            //Actualizo el dto
            dto.CajaId = empleado.CajaId;
            dto.EstadoId = estado.Id;
            dto.NumeracionFacturaId = numeracionFactura.Id;
            dto.NumeroFactura = codigo;
            dto.CreateAt = DateTime.UtcNow.AddHours(-5);

            Factura factura = _mapper.Map<Factura>(dto);
            factura.Orden = null!;
            factura = await _data.Save(factura);

            return _mapper.Map<FacturaDto>(factura);
        }

        public async Task<Archivo> GenerarFactura(int facturaId)
        {
            Archivo archivo = new Archivo();
            Factura factura = await _data.GetById(facturaId);

            IEnumerable<FacturaDetalleDto> facturaDetalles = await _dataFacturaDetalle.GetDataTable(new QueryFilterDto { ForeignKey = factura.Id, NameForeignKey = "FacturaId" });
            IEnumerable<FacturaDetallePagoDto> facturaDetallesPagos = await _dataFacturaDetallePago.GetDataTable(new QueryFilterDto { ForeignKey = factura.Id, NameForeignKey = "FacturaId" });

            using (MemoryStream memoryStream = new MemoryStream())
            {
                Rectangle envelope = new Rectangle(200, 3500);
                Document document = new Document(envelope);

                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                writer.CloseStream = false;

                await ModificaPdf(document, factura, facturaDetalles, facturaDetallesPagos);
                document.Close();

                byte[]
                pdfBytes = memoryStream.ToArray();

                string base64Content = Convert.ToBase64String(pdfBytes);

                archivo = new Archivo()
                {
                    Activo = true,
                    CreateAt = DateTime.UtcNow.AddHours(-5),
                    Nombre = "Factura",
                    TablaId = factura.Id,
                    Tabla = "Facturas",
                    Extension = "pdf",
                    Content = base64Content
                };

                await _dataArchivo.Save(archivo);
            }
            return archivo;
        }

        public async Task ModificaPdf(Document doc, Factura factura, IEnumerable<FacturaDetalleDto> facturaDetalles, IEnumerable<FacturaDetallePagoDto> facturaDetallesPagos)
        {
            Empleado empleado = await _dataEmpleado.GetById(factura.EmpleadoId);
            Caja caja = await _dataCaja.GetById(empleado.CajaId);
            Persona perEmpleado = await _dataPersona.GetById(empleado.PersonaId);
            Empresa empresa = await _dataEmpresa.GetById(empleado.EmpresaId);
            Cliente cliente = await _dataCliente.GetById(factura.ClienteId);
            Persona perCliente = await _dataPersona.GetById(cliente.PersonaId);
            Archivo logoEmpresa = await _dataArchivo.GetByTablaId(empresa.Id, "Empresas");
            NumeracionFactura numeracionFactura = await _dataNumeracionFactura.GetById(factura.NumeracionFacturaId);

            doc.SetMargins(15f, -30f, 0f, 10f);
            doc.Open();

            Font _titledFont = new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD, BaseColor.BLACK);
            Font _standardFont = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL, BaseColor.BLACK);
            Font _titledFontPrductos = new Font(Font.FontFamily.HELVETICA, 7, Font.BOLD, BaseColor.BLACK);
            Font _standardFontPrductos = new Font(Font.FontFamily.HELVETICA, 7, Font.NORMAL, BaseColor.BLACK);
            Font _comentFont = new Font(Font.FontFamily.HELVETICA, 6, Font.NORMAL, BaseColor.BLACK);

            PdfPCell celLineas = new PdfPCell(new Phrase("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ", _standardFont));
            celLineas.HorizontalAlignment = Element.ALIGN_CENTER;
            celLineas.BorderWidth = 0;

            PdfPTable tblImagen = new PdfPTable(1);
            tblImagen.HorizontalAlignment = Element.ALIGN_CENTER;
            tblImagen.DefaultCell.Border = Rectangle.NO_BORDER;
            float[] widthsTblImagen = new float[] { 70f };
            tblImagen.SetWidths(widthsTblImagen);

            Image imagen = Image.GetInstance(Convert.FromBase64String(logoEmpresa.Content.Replace("data:image/"+ logoEmpresa.Extension + ";base64,", "")));
            float percentage = 100 / imagen.Width;
            imagen.ScalePercent(percentage * 85);

            PdfPCell clImagen = new PdfPCell(imagen);
            clImagen.BorderWidth = 0;
            clImagen.HorizontalAlignment = Element.ALIGN_CENTER;

            tblImagen.AddCell(clImagen);

            // Se crean las tablas (en este caso 3)
            PdfPTable tblFactura = new PdfPTable(1);
            tblFactura.HorizontalAlignment = Element.ALIGN_CENTER;
            tblFactura.DefaultCell.Border = Rectangle.NO_BORDER;
            float[] widths = new float[] { 70f };
            tblFactura.SetWidths(widths);

            PdfPCell cellEspacio = new PdfPCell(new Phrase("\n", _titledFont));
            cellEspacio.BorderWidth = 0;

            PdfPCell clNombreEmpresa = new PdfPCell(new Phrase($"{empresa.RazonSocial}", _titledFont));
            clNombreEmpresa.BorderWidth = 0;
            clNombreEmpresa.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell clNitEmpresa = new PdfPCell(new Phrase($"NIT. {empresa.Nit}", _titledFont));
            clNitEmpresa.BorderWidth = 0;
            clNitEmpresa.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell clDireccionEmpresa = new PdfPCell(new Phrase($"{empresa.Direccion}", _titledFont));
            clDireccionEmpresa.BorderWidth = 0;
            clDireccionEmpresa.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell clTelefonoEmpresa = new PdfPCell(new Phrase($"{empresa.Telefono}", _titledFont));
            clTelefonoEmpresa.BorderWidth = 0;
            clTelefonoEmpresa.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell celFecha = new PdfPCell(new Phrase($"{factura.CreateAt.Day}/{factura.CreateAt.Month}/{factura.CreateAt.Year} {factura.CreateAt.ToShortTimeString()}", _titledFont));
            celFecha.BorderWidth = 0;
            celFecha.HorizontalAlignment = Element.ALIGN_CENTER;

            // se añade las celdas a la tabla
            tblFactura.AddCell(clNombreEmpresa);
            tblFactura.AddCell(clNitEmpresa);
            tblFactura.AddCell(clDireccionEmpresa);
            tblFactura.AddCell(clTelefonoEmpresa);
            tblFactura.AddCell(celFecha);
            tblFactura.AddCell(celLineas);

            PdfPTable tblCliente = new PdfPTable(2);
            tblCliente.HorizontalAlignment = Element.ALIGN_CENTER;
            tblCliente.WidthPercentage = 30;
            float[] widthstblCliente = new float[] { 35f, 65f };
            tblCliente.SetWidths(widthstblCliente);

            PdfPCell clNombreCliente = new PdfPCell(new Phrase("CLIENTE: ", _titledFont));
            clNombreCliente.HorizontalAlignment = Element.ALIGN_LEFT;
            clNombreCliente.BorderWidth = 0;

            PdfPCell celNombreClienteData = new PdfPCell(new Phrase($"{perCliente.PrimerNombre} {perCliente.PrimerApellido}", _standardFont));
            celNombreClienteData.HorizontalAlignment = Element.ALIGN_RIGHT;
            celNombreClienteData.BorderWidth = 0;


            PdfPCell clIdentificacionCliente = new PdfPCell(new Phrase("C.C / NIT: ", _titledFont));
            clIdentificacionCliente.HorizontalAlignment = Element.ALIGN_LEFT;
            clIdentificacionCliente.BorderWidth = 0;

            PdfPCell celIdentificacionClienteData = new PdfPCell(new Phrase($"{perCliente.Documento}", _standardFont));
            celIdentificacionClienteData.HorizontalAlignment = Element.ALIGN_RIGHT;
            celIdentificacionClienteData.BorderWidth = 0;

            PdfPCell clDireccionCliente = new PdfPCell(new Phrase("DIRECCIÓN: ", _titledFont));
            clDireccionCliente.HorizontalAlignment = Element.ALIGN_LEFT;
            clDireccionCliente.BorderWidth = 0;

            PdfPCell celDireccionClienteData = new PdfPCell(new Phrase($"{perCliente.Direccion}", _standardFont));
            celDireccionClienteData.HorizontalAlignment = Element.ALIGN_RIGHT;
            celDireccionClienteData.BorderWidth = 0;

            PdfPCell clTelefonoCliente = new PdfPCell(new Phrase("TELÉFONO: ", _titledFont));
            clTelefonoCliente.HorizontalAlignment = Element.ALIGN_LEFT;
            clTelefonoCliente.BorderWidth = 0;

            PdfPCell celTelefonoClienteData = new PdfPCell(new Phrase($"{perCliente.Telefono}", _standardFont));
            celTelefonoClienteData.HorizontalAlignment = Element.ALIGN_RIGHT;
            celTelefonoClienteData.BorderWidth = 0;

            tblCliente.AddCell(clNombreCliente);
            tblCliente.AddCell(celNombreClienteData);

            tblCliente.AddCell(clIdentificacionCliente);
            tblCliente.AddCell(celIdentificacionClienteData);

            tblCliente.AddCell(clDireccionCliente);
            tblCliente.AddCell(celDireccionClienteData);

            tblCliente.AddCell(clTelefonoCliente);
            tblCliente.AddCell(celTelefonoClienteData);

            celLineas.Colspan = 2;
            tblCliente.AddCell(celLineas);

            PdfPTable tblEmpleado = new PdfPTable(2);
            tblEmpleado.HorizontalAlignment = Element.ALIGN_CENTER;
            tblEmpleado.WidthPercentage = 30;
            float[] widthsttblEmpleado = new float[] { 35f, 65f };
            tblEmpleado.SetWidths(widthsttblEmpleado);

            PdfPCell clNombreEmpleado = new PdfPCell(new Phrase("ATENDIO(a): ", _titledFont));
            clNombreEmpleado.HorizontalAlignment = Element.ALIGN_LEFT;
            clNombreEmpleado.BorderWidth = 0;

            PdfPCell celNombreEmpleadoData = new PdfPCell(new Phrase($"{perEmpleado.PrimerNombre} {perEmpleado.PrimerApellido}", _standardFont));
            celNombreEmpleadoData.HorizontalAlignment = Element.ALIGN_RIGHT;
            celNombreEmpleadoData.BorderWidth = 0;

            PdfPCell clNombreCaja = new PdfPCell(new Phrase("ESTACION: ", _titledFont));
            clNombreCaja.HorizontalAlignment = Element.ALIGN_LEFT;
            clNombreCaja.BorderWidth = 0;

            PdfPCell celNombreCajaData = new PdfPCell(new Phrase($"{caja.Nombre}", _standardFont));
            celNombreCajaData.HorizontalAlignment = Element.ALIGN_RIGHT;
            celNombreCajaData.BorderWidth = 0;

            tblEmpleado.AddCell(clNombreEmpleado);
            tblEmpleado.AddCell(celNombreEmpleadoData);

            tblEmpleado.AddCell(clNombreCaja);
            tblEmpleado.AddCell(celNombreCajaData);

            celLineas.Colspan = 2;
            tblEmpleado.AddCell(celLineas);

            PdfPTable tblDetalles = new PdfPTable(3);
            tblDetalles.HorizontalAlignment = Element.ALIGN_CENTER;
            tblDetalles.DefaultCell.Border = Rectangle.NO_BORDER;
            float[] widthsDescuentos = new float[] { 50f, 15f, 35f };
            tblDetalles.SetWidths(widthsDescuentos);

            PdfPCell clNombreProducto = new PdfPCell(new Phrase("Producto", _titledFontPrductos));
            clNombreProducto.VerticalAlignment = Element.ALIGN_MIDDLE;
            clNombreProducto.HorizontalAlignment = Element.ALIGN_LEFT;
            clNombreProducto.BorderWidth = 0;

            PdfPCell clCantidadProducto = new PdfPCell(new Phrase("CANT", _titledFontPrductos));
            clCantidadProducto.VerticalAlignment = Element.ALIGN_MIDDLE;
            clCantidadProducto.HorizontalAlignment = Element.ALIGN_CENTER;
            clCantidadProducto.BorderWidth = 0;

            PdfPCell clPrecioProducto = new PdfPCell(new Phrase("VALOR", _titledFontPrductos));
            clPrecioProducto.VerticalAlignment = Element.ALIGN_MIDDLE;
            clPrecioProducto.HorizontalAlignment = Element.ALIGN_RIGHT;
            clPrecioProducto.BorderWidth = 0;

            cellEspacio.Colspan = 3;
            tblDetalles.AddCell(clNombreProducto);
            tblDetalles.AddCell(clCantidadProducto);
            tblDetalles.AddCell(clPrecioProducto);

            decimal ValorDescuento = factura.Descuento;
            decimal ValorImpuesto = factura.Iva;

            foreach (FacturaDetalleDto item in facturaDetalles)
            {
                //// se llena la tabla con información
                clNombreProducto = new PdfPCell(new Phrase($"{item.Producto}", _standardFontPrductos));
                clNombreProducto.VerticalAlignment = Element.ALIGN_CENTER;
                clNombreProducto.HorizontalAlignment = Element.ALIGN_LEFT;
                clNombreProducto.BorderWidth = 0;

                clCantidadProducto = new PdfPCell(new Phrase($"{item.Cantidad}", _standardFontPrductos));
                clCantidadProducto.VerticalAlignment = Element.ALIGN_CENTER;
                clCantidadProducto.HorizontalAlignment = Element.ALIGN_CENTER;
                clCantidadProducto.BorderWidth = 0;

                clPrecioProducto = new PdfPCell(new Phrase($"{item.PrecioProducto}", _standardFontPrductos));
                clPrecioProducto.VerticalAlignment = Element.ALIGN_CENTER;
                clPrecioProducto.HorizontalAlignment = Element.ALIGN_RIGHT;
                clPrecioProducto.BorderWidth = 0;

                //se adiciona la celda a la tabla
                tblDetalles.AddCell(clNombreProducto);
                tblDetalles.AddCell(clCantidadProducto);
                tblDetalles.AddCell(clPrecioProducto);
            }

            PdfPTable tblValores = new PdfPTable(2);
            tblValores.HorizontalAlignment = Element.ALIGN_CENTER;
            tblValores.WidthPercentage = 30;
            float[] widthstblValores = new float[] { 60f, 40f };
            tblValores.SetWidths(widthstblValores);

            PdfPCell clSubtotal = new PdfPCell(new Phrase("SUB TOTAL: ", _titledFont));
            clSubtotal.HorizontalAlignment = Element.ALIGN_RIGHT;
            clSubtotal.BorderWidth = 0;

            PdfPCell clSubtotalData = new PdfPCell(new Phrase(string.Format("{0:C0}", factura.SubTotal), _standardFont));
            clSubtotalData.HorizontalAlignment = Element.ALIGN_RIGHT;
            clSubtotalData.BorderWidth = 0;

            PdfPCell clDescuento = new PdfPCell(new Phrase("DESCUENTO: ", _titledFont));
            clDescuento.HorizontalAlignment = Element.ALIGN_RIGHT;
            clDescuento.BorderWidth = 0;

            PdfPCell clDescuentoData = new PdfPCell(new Phrase(ValorDescuento + " %", _standardFont));
            clDescuentoData.HorizontalAlignment = Element.ALIGN_RIGHT;
            clDescuentoData.BorderWidth = 0;

            PdfPCell clImpuesto = new PdfPCell(new Phrase("IMPUESTO: ", _titledFont));
            clImpuesto.HorizontalAlignment = Element.ALIGN_RIGHT;
            clImpuesto.BorderWidth = 0;

            PdfPCell clImpuestoData = new PdfPCell(new Phrase(ValorImpuesto + " %", _standardFont));
            clImpuestoData.HorizontalAlignment = Element.ALIGN_RIGHT;
            clImpuestoData.BorderWidth = 0;


            PdfPCell clTotal = new PdfPCell(new Phrase("TOTAL: ", _titledFont));
            clTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
            clTotal.BorderWidth = 0;

            PdfPCell clTotalData = new PdfPCell(new Phrase(string.Format("{0:C0}", factura.Total), _titledFont));
            clTotalData.HorizontalAlignment = Element.ALIGN_RIGHT;
            clTotalData.BorderWidth = 0;

            celLineas.Colspan = 3;
            tblDetalles.AddCell(celLineas);

            tblValores.AddCell(clSubtotal);
            tblValores.AddCell(clSubtotalData);

            tblValores.AddCell(clDescuento);
            tblValores.AddCell(clDescuentoData);

            tblValores.AddCell(clImpuesto);
            tblValores.AddCell(clImpuestoData);

            tblValores.AddCell(clTotal);
            tblValores.AddCell(clTotalData);

            celLineas.Colspan = 2;
            tblValores.AddCell(celLineas);

            if (facturaDetallesPagos.Count() != 0)
            {
                //// se llena la tabla con información
                PdfPCell clNombreMedioTitle = new PdfPCell(new Phrase("MEDIO DE PAGO", _titledFont));
                clNombreMedioTitle.VerticalAlignment = Element.ALIGN_CENTER;
                clNombreMedioTitle.HorizontalAlignment = Element.ALIGN_RIGHT;
                clNombreMedioTitle.BorderWidth = 0;

                PdfPCell clPrecioMedioPago = new PdfPCell(new Phrase("VALOR", _titledFont));
                clPrecioMedioPago.VerticalAlignment = Element.ALIGN_MIDDLE;
                clPrecioMedioPago.HorizontalAlignment = Element.ALIGN_RIGHT;
                clPrecioMedioPago.BorderWidth = 0;

                tblValores.AddCell(clNombreMedioTitle);
                tblValores.AddCell(clPrecioMedioPago);

                foreach (FacturaDetallePagoDto item in facturaDetallesPagos)
                {
                    //IEnumerable<FacturaDetallePagoDto> facturaDetallePago = await _dataFacturaDetallePago.GetDataTable(new QueryFilterDto() { ForeignKey = factura.Id, NameForeignKey = "FacturaId" });

                    //se llena la tabla con información
                    PdfPCell clNombreMedioPago = new PdfPCell(new Phrase($"{item.MedioPago}", _titledFont));
                    clNombreMedioPago.VerticalAlignment = Element.ALIGN_CENTER;
                    clNombreMedioPago.HorizontalAlignment = Element.ALIGN_RIGHT;
                    clNombreMedioPago.BorderWidth = 0;

                    PdfPCell clNombreMedioPagoData = new PdfPCell(new Phrase(string.Format("{0:C0}", item.Valor), _standardFont));
                    clNombreMedioPagoData.VerticalAlignment = Element.ALIGN_CENTER;
                    clNombreMedioPagoData.HorizontalAlignment = Element.ALIGN_RIGHT;
                    clNombreMedioPagoData.BorderWidth = 0;

                    //se adiciona la celda a la tabla
                    tblValores.AddCell(clNombreMedioPago);
                    tblValores.AddCell(clNombreMedioPagoData);
                }
            }

            PdfPTable tblObservaciones = new PdfPTable(1);
            tblObservaciones.HorizontalAlignment = Element.ALIGN_CENTER;
            tblObservaciones.WidthPercentage = 30;
            float[] widthstblObservaciones = new float[] { 100f };
            tblObservaciones.SetWidths(widthstblObservaciones);

            var tituloFactura = "FACTURA DE VENTA N° ";
            if (factura.Remision)
            {
                tituloFactura = "REMISIÓN N° ";
            }

            PdfPCell cellTituloFactura = new PdfPCell(new Phrase(tituloFactura + factura.NumeroFactura, _titledFont));
            cellTituloFactura.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTituloFactura.BorderWidth = 0;

            PdfPCell celNumeracionFactura = new PdfPCell(new Phrase($"{numeracionFactura.Autorizacion}", _titledFont));
            celNumeracionFactura.HorizontalAlignment = Element.ALIGN_CENTER;
            celNumeracionFactura.BorderWidth = 0;

            tblObservaciones.AddCell(celLineas);
            tblObservaciones.AddCell(cellTituloFactura);
            tblObservaciones.AddCell(celLineas);
            tblObservaciones.AddCell(celNumeracionFactura);
            tblObservaciones.AddCell(celLineas);


            PdfPCell clFooterFactura = new PdfPCell(new Phrase("GCSOF - SIGEC© 2017 - " + DateTime.UtcNow.AddHours(-5).Year + "\n" + " SISTEMA DE GESTIÓN Y CONTROL." + "\n" + "SOFTWARE DESARROLLADO POR sigec.gcsof.com" + "\n" + "CEL: 3112136100" + "\n" + "info@gcsof.com", _comentFont));
            clFooterFactura.HorizontalAlignment = Element.ALIGN_CENTER;
            clFooterFactura.BorderWidth = 0;
            tblObservaciones.AddCell(clFooterFactura);

            // Finalmente, se añade la tabla al documento PDF y se cierra el documento
            PdfPTable tblGeneral = new PdfPTable(1);
            tblGeneral.HorizontalAlignment = Element.ALIGN_LEFT;
            tblGeneral.DefaultCell.Border = Rectangle.NO_BORDER;

            tblGeneral.AddCell(tblImagen);
            tblGeneral.AddCell(tblFactura);
            tblGeneral.AddCell(tblCliente);
            tblGeneral.AddCell(tblDetalles);
            tblGeneral.AddCell(tblValores);
            tblGeneral.AddCell(tblObservaciones);
            doc.Add(tblGeneral);

            doc.Close();
        }

        public async Task<Archivo> GetArchivoById(int id)
        {
            Archivo archivo = await _dataArchivo.GetByTablaId(id, "Facturas");
            return archivo;
        }

        public async Task Anular(int id, int empleadoId)
        {
            Factura factura = await _data.GetById(id);
            Estado estado = await _dataEstado.GetByCode("ANULADA");

            if (factura.EstadoId == estado.Id)
            {
                throw new Exception("La factura ya se encuentra anulada.");
            }

            //Actualizo el estado de la factura
            factura.EstadoId = estado.Id;
            factura.UpdateAt = DateTime.UtcNow.AddHours(-5);
            await _data.Update(factura);

            //Consulto los detalles de la factura
            IEnumerable<FacturaDetalleDto> detalles = await _dataFacturaDetalle.GetDataTable(new QueryFilterDto { ForeignKey = factura.Id, NameForeignKey = "FacturaId" });

            //Actualizo los detalles
            foreach (var detalle in detalles)
            {
                List<DetalleInventarioBodegaDto> detalleBodega = (List<DetalleInventarioBodegaDto>)await _dataInsumoProducto.GetOrdenDetalle(new QueryFilterDto { ForeignKey = detalle.ProductoId });
                await DevolverInventario(detalleBodega, detalle, factura, empleadoId);
            }
        }

        public async Task DevolverInventario(List<DetalleInventarioBodegaDto> detalleBodega, FacturaDetalleDto detalleFactura, Factura factura, int empleadoId)
        {
            var tipoFactura = "factura de venta";
            if (factura.Remision)
            {
                tipoFactura = "remisión";
            }

            for (int i = 0; i < detalleBodega.Count(); i++)
            {
                if (i == 0)
                {
                    //Consulto el inventario detalle
                    InventarioDetalle inventarioDetalle = await _dataInventarioDetalle.GetById(detalleBodega[i].InventarioDetalleId);

                    //Actualizo las cantidades de inventario detalle
                    inventarioDetalle.CantidadTotal += detalleFactura.Cantidad;
                    inventarioDetalle.CantidadUsada -= detalleFactura.Cantidad;
                    inventarioDetalle.UpdateAt = DateTime.UtcNow.AddHours(-5);
                    await _dataInventarioDetalle.Update(inventarioDetalle);

                    //Creo la bitacora de inventario
                    BitacoraInventario bitacoraInventario = new BitacoraInventario()
                    {
                        Codigo = await _businessBitacoraInventario.GenerarCodigo(),
                        Cantidad = detalleFactura.Cantidad,
                        Observacion = $"Se devuelve {detalleFactura.Cantidad} del Insumo {detalleBodega[i].Insumo} por anulación de {tipoFactura} # {factura.NumeroFactura}, Cantidad anterior: {inventarioDetalle.CantidadTotal - detalleFactura.Cantidad}, Cantidad Actual: {inventarioDetalle.CantidadTotal}",
                        EmpleadoId = empleadoId,
                        InsumoId = inventarioDetalle.InsumoId,
                        Activo = true,
                        CreateAt = DateTime.UtcNow.AddHours(-5),
                        Empleado = null!,
                        Insumo = null!,
                    };
                    // Guardo la bitacora de inventario
                    _ = await _dataBitacoraInventario.Save(bitacoraInventario);
                }
            }
        }

    }
}
