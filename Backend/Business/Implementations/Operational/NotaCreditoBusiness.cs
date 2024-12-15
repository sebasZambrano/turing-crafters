using AutoMapper;
using Business.Interfaces.Inventory;
using Business.Interfaces.Operational;
using Data.Interfaces;
using Data.Interfaces.Inventory;
using Data.Interfaces.Operational;
using Data.Interfaces.Parameter;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Dtos.Operational;
using Entity.Dtos.Parameter;
using Entity.Models.Inventory;
using Entity.Models.Operational;
using Entity.Models.Parameter;

namespace Business.Implementations.Operational
{
    public class NotaCreditoBusiness : BaseModelBusiness<NotaCredito, NotaCreditoDto>, INotaCreditoBusiness
    {
        private readonly INotaCreditoData _data;
        private readonly IEstadoData _dataEstado;
        private readonly IFacturaData _dataFactura;
        private readonly IFacturaDetalleData _dataFacturaDetalle;
        private readonly IInsumoProductoData _dataInsumoProducto;
        private readonly IInventarioDetalleData _dataInventarioDetalle;
        private readonly INumeracionFacturaData _dataNumeracionFactura;
        private readonly IBitacoraInventarioData _dataBitacoraInventario;
        private readonly IEmpleadoData _dataEmpleado;
        private readonly INotaCreditoDetalleData _dataNotaCreditoDetalle;
        private readonly IBaseModelData<TipoCosto, TipoCostoDto> _dataTipoCosto;
        private readonly IBitacoraInventarioBusiness _businessBitacoraInventario;
        private readonly ICostoBusiness _businessCosto;
        private readonly IBitacoraFacturaBusiness _businessBitacoraFactura;
        private readonly IBitacoraFacturaData _dataBitacoraFactura;
        private readonly IMapper _mapper;

        public NotaCreditoBusiness(INotaCreditoData data, IEstadoData dataEstado,
                                   IFacturaData dataFactura, INumeracionFacturaData dataNumeracionFactura,
                                   IFacturaDetalleData dataFacturaDetalle, IInsumoProductoData dataInsumoProducto,
                                   IInventarioDetalleData dataInventarioDetalle, IBitacoraInventarioData dataBitacoraInventario,
                                   IBaseModelData<TipoCosto, TipoCostoDto> dataTipoCosto, IEmpleadoData dataEmpleado,
                                   INotaCreditoDetalleData dataNotaCreditoDetalle,
                                   IBitacoraInventarioBusiness businessBitacoraInventario, ICostoBusiness businessCosto,
                                   IBitacoraFacturaBusiness businessBitacoraFactura, IBitacoraFacturaData dataBitacoraFactura,
                                   IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _dataEstado = dataEstado;
            _dataFactura = dataFactura;
            _dataFacturaDetalle = dataFacturaDetalle;
            _dataNumeracionFactura = dataNumeracionFactura;
            _dataInsumoProducto = dataInsumoProducto;
            _dataInventarioDetalle = dataInventarioDetalle;
            _dataBitacoraInventario = dataBitacoraInventario;
            _dataTipoCosto = dataTipoCosto;
            _dataEmpleado = dataEmpleado;
            _dataNotaCreditoDetalle = dataNotaCreditoDetalle;
            _businessBitacoraInventario = businessBitacoraInventario;
            _businessCosto = businessCosto;
            _dataBitacoraFactura = dataBitacoraFactura;
            _businessBitacoraFactura = businessBitacoraFactura;
            _mapper = mapper;
        }

        public override async Task<NotaCreditoDto> Save(NotaCreditoDto dto)
        {
            List<FacturaDetalleDto> detalles = dto.FacturaDetalles;
            Estado estado = await _dataEstado.GetByCode("NC-1");
            dto.EstadoId = estado.Id;
            dto.Codigo = await GenerarCodigo();
            dto.CreateAt = DateTime.UtcNow.AddHours(-5);
            NotaCredito entity = _mapper.Map<NotaCredito>(dto);
            entity = await _data.Save(entity);

            //Guardo los detalles de la nota crédito
            await SaveDetails(detalles, entity);

            return _mapper.Map<NotaCreditoDto>(entity);
        }

        public override async Task Update(NotaCreditoDto dto)
        {
            Estado estado = await _dataEstado.GetById(dto.EstadoId);
            NotaCredito entity = _mapper.Map<NotaCredito>(dto);
            entity.UpdateAt = DateTime.UtcNow.AddHours(-5);
            await _data.Update(entity);

            //Vaalido si el estado es APROBADA
            if (estado.Codigo == "NC-2")
            {
                //Agregar un costo de tipo nota credito
                //if (entity.PagoCaja)
                //{
                //    //Consulto el tipo costo
                //    TipoCosto tipoCosto = await _dataTipoCosto.GetByCode("NC");

                //    //Consulto el empleado
                //    Empleado empleado = await _dataEmpleado.GetById(entity.EmpleadoId);

                //    //Agrego un costo
                //    CostoDto costo = new CostoDto()
                //    {
                //        Descripcion = $"Costo asociado a la nota de credito # {entity.Codigo}",
                //        FechaCosto = DateTime.UtcNow.AddHours(-5),
                //        Valor = entity.Total,
                //        PagoCaja = entity.PagoCaja,
                //        NumeroFactura = entity.Codigo,
                //        EmpleadoId = empleado.Id,
                //        CajaId = empleado.CajaId,
                //        TipoCostoId = tipoCosto.Id,
                //        ProveedorId = 0,
                //        Activo = true,
                //    };

                //    _ = await _businessCosto.Save(costo);
                //}

                // Actualizo los detalles de la notas de credito
                await UpdateDetails(dto.FacturaDetalles);

                //Devuelvo las cantidades a inventario
                await ReturnInventory(dto.FacturaDetalles, entity);
            }
        }

        public async Task SaveDetails(List<FacturaDetalleDto> facturaDetalles, NotaCredito notaCredito)
        {
            foreach (var dto in facturaDetalles)
            {
                NotaCreditoDetalle detalle = new NotaCreditoDetalle()
                {
                    Id = 0,
                    Activo = true,
                    CreateAt = DateTime.UtcNow.AddHours(-5),
                    NotaCreditoId = notaCredito.Id,
                    FacturaDetalleId = dto.Id,
                    Cantidad = dto.Cantidad,
                    UpdateAt = null!,
                    DeleteAt = null!,
                    NotaCredito = null!,
                    FacturaDetalle = null!,
                };

                _ = await _dataNotaCreditoDetalle.Save(detalle);
            }
        }

        public async Task UpdateDetails(List<FacturaDetalleDto> facturaDetalles)
        {
            IEnumerable<NotaCreditoDetalleDto> detallesNotasCreditoDto = await _dataNotaCreditoDetalle.GetDataTable(new QueryFilterDto() { ForeignKey = facturaDetalles.First().Id, NameForeignKey = "FacturaDetalleId" });
            
            foreach (var item in detallesNotasCreditoDto)
            {
                //Actualizo los detalles
                item.Activo = false;
                item.NotaCredito = null!;
                item.FacturaDetalle = null!;
                item.Codigo = null!;
                item.Producto = null!;
                item.PrecioProducto = null!;
                NotaCreditoDetalle detalle = _mapper.Map<NotaCreditoDetalle>(item);
                detalle.UpdateAt = DateTime.UtcNow.AddHours(-5);
                await _dataNotaCreditoDetalle.Update(detalle);
            }
        }

        public async Task ReturnInventory(List<FacturaDetalleDto> facturaDetalles, NotaCredito notaCredito)
        {
            Factura factura = await _dataFactura.GetById(notaCredito.FacturaId);
            var tipoFactura = "factura de venta";

            if (factura.Remision)
            {
                tipoFactura = "remisión";
            }

            foreach (var dto in facturaDetalles)
            {
                //Actualizo los detalles
                dto.Activo = false;
                dto.FacturaId = notaCredito.FacturaId;
                dto.EmpleadoId = notaCredito.EmpleadoId;
                FacturaDetalle facturaDetalle = _mapper.Map<FacturaDetalle>(dto);
                facturaDetalle.UpdateAt = DateTime.UtcNow.AddHours(-5);
                await _dataFacturaDetalle.Update(facturaDetalle);

                IEnumerable<InsumoProductoDto> insumosProductos = await _dataInsumoProducto.GetDataTable(new QueryFilterDto() { ForeignKey = facturaDetalle.ProductoId, NameForeignKey = "ProductoId" });
                foreach (var insumoProducto in insumosProductos)
                {
                    //Consulto el inventario detalle
                    IEnumerable<InventarioDetalleDto> inventarioDetalles = await _dataInventarioDetalle.GetDataTable(new QueryFilterDto() { ForeignKey = insumoProducto.InsumoId, NameForeignKey = "InsumoId" });
                    InventarioDetalle inventarioDetalle = await _dataInventarioDetalle.GetById(inventarioDetalles.First().Id);

                    //Actualizo las cantidades de inventario detalle
                    inventarioDetalle.CantidadTotal += facturaDetalle.Cantidad;
                    inventarioDetalle.CantidadUsada -= facturaDetalle.Cantidad;
                    inventarioDetalle.UpdateAt = DateTime.UtcNow.AddHours(-5);
                    await _dataInventarioDetalle.Update(inventarioDetalle);

                    //Creo la bitacora de inventario
                    BitacoraInventario bitacoraInventario = new BitacoraInventario()
                    {
                        Codigo = await _businessBitacoraInventario.GenerarCodigo(),
                        Cantidad = facturaDetalle.Cantidad,
                        Observacion = $"Se devuelve {facturaDetalle.Cantidad} del Insumo {insumoProducto.Insumo} por nota de crédito de {tipoFactura} # {factura.NumeroFactura}, Cantidad anterior: {inventarioDetalle.CantidadTotal - facturaDetalle.Cantidad}, Cantidad Actual: {inventarioDetalle.CantidadTotal}",
                        EmpleadoId = notaCredito.EmpleadoId,
                        InsumoId = inventarioDetalle.InsumoId,
                        Activo = true,
                        CreateAt = DateTime.UtcNow.AddHours(-5),
                        Empleado = null!,
                        Insumo = null!,
                    };
                    // Guardo la bitacora de inventario
                    _ = await _dataBitacoraInventario.Save(bitacoraInventario);

                    //Creo la bitacora de factura
                    BitacoraFactura bitacoraFactura = new BitacoraFactura()
                    {
                        Codigo = await _businessBitacoraFactura.GenerarCodigo(),
                        Cantidad = facturaDetalle.Cantidad,
                        Observacion = $"Se devuelve {facturaDetalle.Cantidad} del Insumo {insumoProducto.Insumo} por nota de crédito de {tipoFactura} # {factura.NumeroFactura}.",
                        EmpleadoId = notaCredito.EmpleadoId,
                        InsumoId = inventarioDetalle.InsumoId,
                        FacturaId = factura.Id,
                        Activo = true,
                        CreateAt = DateTime.UtcNow.AddHours(-5),
                        Empleado = null!,
                        Factura = null!,
                        Insumo = null!,
                    };

                    // Guardo la bitacora de factura
                    _ = await _dataBitacoraFactura.Save(bitacoraFactura);
                }
            }
        }

        public async Task<string> GenerarCodigo()
        {
            NumeracionFactura numeracionFactura = await _dataNumeracionFactura.GetByCode("NC");

            numeracionFactura.NumActual = ++numeracionFactura.NumActual;
            numeracionFactura.UpdateAt = DateTime.UtcNow.AddHours(-5);
            await _dataNumeracionFactura.Update(numeracionFactura);

            string codigo = $"{numeracionFactura.Prefijo}-{DateTime.UtcNow.AddHours(-5).Year}-{numeracionFactura.NumActual}";
            return codigo;
        }
    }
}
