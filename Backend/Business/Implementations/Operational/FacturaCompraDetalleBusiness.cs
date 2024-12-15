using AutoMapper;
using Business.Implementations.Inventory;
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
    public class FacturaCompraDetalleBusiness : BaseModelBusiness<FacturaCompraDetalle, FacturaCompraDetalleDto>, IFacturaCompraDetalleBusiness
    {
        private readonly IFacturaCompraDetalleData _data;
        private readonly IInventarioDetalleData _dataInventarioDetalle;
        private readonly IDetalleInventarioBodegaData _dataDetalleInventarioBodega;
        private readonly IBitacoraInventarioData _dataBitacoraInventario;
        private readonly IBitacoraInventarioBodegaData _dataBitacoraInventarioBodega;
        private readonly IBitacoraInventarioBusiness _businessBitacoraInventario;
        private readonly IFacturaCompraData _dataFacturaCompra;
        private readonly IInsumoData _dataInsumo;
        private readonly IBitacoraInventarioBodegaBusiness _bitacoraInventarioBodegaBusiness;
        private readonly IMapper _mapper;

        public FacturaCompraDetalleBusiness(IFacturaCompraDetalleData data,
            IDetalleInventarioBodegaData dataDetalleInventarioBodega,
            IInventarioDetalleData dataInventarioDetalle,
            IBitacoraInventarioBusiness businessBitacoraInventario,
            IBitacoraInventarioData dataBitacoraInventario,
            IFacturaCompraData dataFacturaCompra,
            IBitacoraInventarioBodegaData dataBitacoraInventarioBodega,
            IInsumoData dataInsumo,
            IBitacoraInventarioBodegaBusiness bitacoraInventarioBodegaBusiness,
            IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _dataDetalleInventarioBodega = dataDetalleInventarioBodega;
            _dataInventarioDetalle = dataInventarioDetalle;
            _dataFacturaCompra = dataFacturaCompra;
            _dataBitacoraInventario = dataBitacoraInventario;
            _dataBitacoraInventarioBodega = dataBitacoraInventarioBodega;
            _dataInsumo = dataInsumo;
            _bitacoraInventarioBodegaBusiness = bitacoraInventarioBodegaBusiness;
            _businessBitacoraInventario = businessBitacoraInventario;
            _mapper = mapper;
        }

        public override async Task<FacturaCompraDetalleDto> Save(FacturaCompraDetalleDto dto)
        {
            //Consulto los detalles de la factura de compra
            IEnumerable<FacturaCompraDetalleDto> lstFacturaCompraDetalles = await _data.GetDataTable(new QueryFilterDto() { ForeignKey = dto.FacturaCompraId, NameForeignKey = "FacturaCompraId" });
            decimal ValorTotalDetalles = lstFacturaCompraDetalles.Sum(i => i.SubTotal);

            //Consulto la factura de compra
            FacturaCompra factura = await _dataFacturaCompra.GetById(dto.FacturaCompraId);


            decimal diferencia = factura.Total - ValorTotalDetalles;
            FacturaCompraDetalle detalle = new FacturaCompraDetalle();

            if (diferencia > 0)
            {
                if (dto.SubTotal > diferencia)
                {
                    throw new Exception("El sub Total del insumo supero el total de la factura de compra.");
                }
                dto.CreateAt = DateTime.UtcNow.AddHours(-5);
                detalle = _mapper.Map<FacturaCompraDetalle>(dto);
                detalle = await _data.Save(detalle);
            }
            else
            {
                throw new Exception("No se guardo el insumo, no se puede superar el precio total de la factura de compra.");
            }


            //Consulto los detalles del inventario por el InsumoId
            InventarioDetalleDto inventarioDetalle = (await _dataInventarioDetalle.GetDataTable(new QueryFilterDto { ForeignKey = detalle.InsumoId, NameForeignKey = "InsumoId" })).First();

            //Actualizo las cantidades de inventario detalle
            inventarioDetalle.CantidadTotal += detalle.Cantidad;
            inventarioDetalle.CantidadIngresada += detalle.Cantidad;
            inventarioDetalle.PrecioCosto = detalle.PrecioCosto;
            inventarioDetalle.Inventario = null!;
            inventarioDetalle.Insumo = null!;
            InventarioDetalle inventarioDet = _mapper.Map<InventarioDetalle>(inventarioDetalle);
            inventarioDet.UpdateAt = DateTime.UtcNow.AddHours(-5);
            await _dataInventarioDetalle.Update(inventarioDet);

            //Consulto el insumo
            Insumo insumo = await _dataInsumo.GetById(inventarioDetalle.InsumoId);

            //Creo la bitacora de inventario
            BitacoraInventario bitacoraInventario = new BitacoraInventario()
            {
                Codigo = await _businessBitacoraInventario.GenerarCodigo(),
                Cantidad = detalle.Cantidad,
                Observacion = $"Se agregan {detalle.Cantidad} del {insumo.Nombre} al inevntario de la factura de compra # {factura.NumeroFactura}, Cantidad anterior: {inventarioDetalle.CantidadTotal - detalle.Cantidad}, Cantidad Actual: {inventarioDetalle.CantidadTotal}",
                EmpleadoId = dto.EmpleadoId,
                InsumoId = detalle.InsumoId,
                Activo = true,
                CreateAt = DateTime.UtcNow.AddHours(-5),
                Empleado = null!,
                Insumo = null!,
            };

            _ = await _dataBitacoraInventario.Save(bitacoraInventario);

            return _mapper.Map<FacturaCompraDetalleDto>(detalle);
        }

        public async Task<int> Delete(int id, int idEmpleado)
        {
            FacturaCompraDetalle detalle = await _data.GetById(id);

            //Consulto la factura de compra
            FacturaCompra factura = await _dataFacturaCompra.GetById(detalle.FacturaCompraId);

            InventarioDetalleDto inventarioDetalle = (await _dataInventarioDetalle.GetDataTable(new QueryFilterDto { ForeignKey = detalle.InsumoId, NameForeignKey = "InsumoId" })).First();

            //Actualizo las cantidades de inventario detalle
            inventarioDetalle.CantidadTotal -= detalle.Cantidad;
            inventarioDetalle.CantidadIngresada -= detalle.Cantidad;
            inventarioDetalle.PrecioCosto = detalle.PrecioCosto;
            inventarioDetalle.Inventario = null!;
            inventarioDetalle.Insumo = null!;
            InventarioDetalle inventarioDet = _mapper.Map<InventarioDetalle>(inventarioDetalle);
            inventarioDet.UpdateAt = DateTime.UtcNow.AddHours(-5);
            await _dataInventarioDetalle.Update(inventarioDet);

            //Consulto el insumo
            Insumo insumo = await _dataInsumo.GetById(inventarioDetalle.InsumoId);

            //Creo la bitacora de inventario
            BitacoraInventario bitacoraInventario = new BitacoraInventario()
            {
                Codigo = await _businessBitacoraInventario.GenerarCodigo(),
                Cantidad = detalle.Cantidad,
                Observacion = $"Se descuentan {detalle.Cantidad} del {insumo.Nombre} del inevntario de la factura de compra # {factura.NumeroFactura} por error a la hora de agregar el detalle a la factura de compra, Cantidad anterior: {inventarioDetalle.CantidadTotal + detalle.Cantidad}, Cantidad Actual: {inventarioDetalle.CantidadTotal}",
                EmpleadoId = idEmpleado,
                InsumoId = detalle.InsumoId,
                Activo = true,
                CreateAt = DateTime.UtcNow.AddHours(-5),
                Empleado = null!,
                Insumo = null!,
            };

            _ = await _dataBitacoraInventario.Save(bitacoraInventario);

            IEnumerable<BitacoraInventarioBodegaDto> bitacorasInventario = await _dataBitacoraInventarioBodega.GetDataTable(new QueryFilterDto() { ForeignKey = factura.Id, NameForeignKey = "FacturaCompraId" });
            
            foreach (var item in bitacorasInventario)
            {
                DetalleInventarioBodegaDto detalleInventarioBodegaDto = (await _dataDetalleInventarioBodega.GetDataTable(new QueryFilterDto { ForeignKey = item.DetalleInventarioBodegaId, NameForeignKey = "Id" })).First();
                
                //Actualizo las cantidades de inventarioDetalleBodega
                detalleInventarioBodegaDto.Cantidad -= item.Cantidad;
                detalleInventarioBodegaDto.Bodega = null!;
                detalleInventarioBodegaDto.InventarioDetalle = null!;
                detalleInventarioBodegaDto.Insumo = null!;
                
                DetalleInventarioBodega detalleInventarioBodega = _mapper.Map<DetalleInventarioBodega>(detalleInventarioBodegaDto);
                detalleInventarioBodega.UpdateAt = DateTime.UtcNow.AddHours(-5);
                await _dataDetalleInventarioBodega.Update(detalleInventarioBodega);

                BitacoraInventarioBodegaDto bitacoraInventarioBodegaDto = new BitacoraInventarioBodegaDto()
                {
                    Id = 0,
                    Activo = true,
                    CreateAt = DateTime.UtcNow.AddHours(-5),
                    Codigo = await _bitacoraInventarioBodegaBusiness.GenerarCodigo(),
                    Cantidad = item.Cantidad,
                    Observacion = $"Se descuentan {item.Cantidad} del {insumo.Nombre} de la bodega de la factura de compra # {factura.NumeroFactura} por error a la hora de agregar el detalle a la factura de compra, Cantidad anterior: {detalleInventarioBodega.Cantidad + item.Cantidad}, Cantidad Actual: {detalleInventarioBodega.Cantidad}",
                    DetalleInventarioBodegaId = detalleInventarioBodegaDto.Id,
                    EmpleadoId = idEmpleado,
                    FacturaCompraId = null!,
                };
                
                _ = await _bitacoraInventarioBodegaBusiness.Save(bitacoraInventarioBodegaDto);
            }

            return await _data.Delete(id);
        }
    }
}
