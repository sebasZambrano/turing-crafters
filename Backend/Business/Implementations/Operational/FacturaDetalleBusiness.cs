using AutoMapper;
using Business.Interfaces.Inventory;
using Business.Interfaces.Operational;
using Data.Interfaces.Inventory;
using Data.Interfaces.Operational;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Dtos.Operational;
using Entity.Models.Inventory;
using Entity.Models.Operational;

namespace Business.Implementations.Operational
{
    public class FacturaDetalleBusiness : BaseModelBusiness<FacturaDetalle, FacturaDetalleDto>, IFacturaDetalleBusiness
    {
        private readonly IFacturaDetalleData _data;
        private readonly IFacturaData _dataFacturas;
        private readonly IInventarioDetalleData _dataInventarioDetalle;
        private readonly IBitacoraInventarioData _dataBitacoraInventario;
        private readonly IDetalleInventarioBodegaData _dataDetalleInventarioBodega;
        private readonly IBitacoraInventarioBusiness _businessBitacoraInventario;
        private readonly IBitacoraFacturaBusiness _businessBitacoraFactura;
        private readonly IInsumoProductoData _dataInsumoProducto;
        private readonly IBitacoraFacturaData _dataBitacoraFactura;
        private readonly IMapper _mapper;

        public FacturaDetalleBusiness(IFacturaDetalleData data,
            IFacturaData dataFacturas,
            IInventarioDetalleData dataInventarioDetalle,
            IBitacoraInventarioData dataBitacoraInventario,
            IBitacoraInventarioBusiness businessBitacoraInventario,
            IBitacoraFacturaBusiness businessBitacoraFactura,
            IDetalleInventarioBodegaData dataDetalleInventarioBodega,
            IInsumoProductoData dataInsumoProducto,
            IBitacoraFacturaData dataBitacoraFactura,
            IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _dataFacturas = dataFacturas;
            _mapper = mapper;
            _dataInventarioDetalle = dataInventarioDetalle;
            _dataBitacoraInventario = dataBitacoraInventario;
            _businessBitacoraInventario = businessBitacoraInventario;
            _dataDetalleInventarioBodega = dataDetalleInventarioBodega;
            _dataInsumoProducto = dataInsumoProducto;
            _businessBitacoraFactura = businessBitacoraFactura;
            _dataBitacoraFactura = dataBitacoraFactura;
        }

        public async Task SaveDetalles(FacturaDetalleDto[] facturasDetallesDto)
        {
            var facturasDetalles = _mapper.Map<FacturaDetalle[]>(facturasDetallesDto);
            await _data.SaveDetalles(facturasDetalles);

            //Consulto la factura
            Factura factura = await _dataFacturas.GetById(facturasDetallesDto.First().FacturaId);

            foreach (var item in facturasDetallesDto)
            {
                IEnumerable<InsumoProductoDto> lstInsumoProducto = await _dataInsumoProducto.GetDataTable(new QueryFilterDto () { ForeignKey = item.ProductoId, NameForeignKey = "ProductoId" });
                InsumoProductoDto insumoProductoDto = lstInsumoProducto.First();

                InventarioDetalle inventarioDetalle = await _dataInventarioDetalle.GetById(item.DetallesInventariosBodegas.First().InventarioDetalleId);

                //Actualizo las cantidades de inventario detalle
                inventarioDetalle.CantidadTotal -= item.Cantidad;
                inventarioDetalle.CantidadUsada += item.Cantidad;
                inventarioDetalle.UpdateAt = DateTime.UtcNow.AddHours(-5);
                await _dataInventarioDetalle.Update(inventarioDetalle);

                //Creo la bitacora de inventario
                BitacoraInventario bitacoraInventario = new BitacoraInventario()
                {
                    Codigo = await _businessBitacoraInventario.GenerarCodigo(),
                    Cantidad = item.Cantidad,
                    Observacion = $"Se descuenta { item.Cantidad } del Insumo { insumoProductoDto.Insumo } por factura de venta # {factura.NumeroFactura } , Cantidad anterior: { inventarioDetalle.CantidadTotal + item.Cantidad }, Cantidad Actual: { inventarioDetalle.CantidadTotal }",
                    EmpleadoId = item.EmpleadoId,
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
                    Cantidad = item.Cantidad,
                    Observacion = $"Se vende {item.Cantidad} del Insumo {insumoProductoDto.Insumo} por factura de venta # {factura.NumeroFactura}.",
                    EmpleadoId = item.EmpleadoId,
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

                foreach (var element in item.DetallesInventariosBodegas)
                {
                    //Actualizo las cantidades de detalle Inevntario Bodega
                    DetalleInventarioBodega detalleInventarioBodega = await _dataDetalleInventarioBodega.GetById(element.Id);
                    detalleInventarioBodega.Cantidad -= element.CantidadFacturar;
                    detalleInventarioBodega.UpdateAt = DateTime.UtcNow.AddHours(-5);

                    await _dataDetalleInventarioBodega.Update(_mapper.Map<DetalleInventarioBodega>(detalleInventarioBodega));
                }
            }
        }
    }
}
