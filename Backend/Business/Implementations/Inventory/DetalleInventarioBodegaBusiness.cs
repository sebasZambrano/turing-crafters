using AutoMapper;
using Business.Interfaces.Inventory;
using Data.Interfaces.Inventory;
using Data.Interfaces.Operational;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;
using Entity.Models.Operational;

namespace Business.Implementations.Inventory
{
    public class DetalleInventarioBodegaBusiness : BaseModelBusiness<DetalleInventarioBodega, DetalleInventarioBodegaDto>, IDetalleInventarioBodegaBusiness
    {
        private readonly IDetalleInventarioBodegaData _data;
        private readonly IFacturaCompraData _dataFacturaCompra;
        private readonly IInventarioDetalleData _dataInventarioDetalle;
        private readonly IInsumoData _dataInsumo;
        private readonly IBitacoraInventarioBodegaBusiness _bitacoraInventarioBodegaBusiness;
        private readonly IMapper _mapper;

        public DetalleInventarioBodegaBusiness(IDetalleInventarioBodegaData data, IFacturaCompraData dataFacturaCompra,
                                                IInventarioDetalleData dataInventarioDetalle, IInsumoData dataInsumo,
                                                IBitacoraInventarioBodegaBusiness bitacoraInventarioBodegaBusiness,
                                                IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _dataFacturaCompra = dataFacturaCompra;
            _dataInventarioDetalle = dataInventarioDetalle;
            _dataInsumo = dataInsumo;
            _bitacoraInventarioBodegaBusiness = bitacoraInventarioBodegaBusiness;
            _mapper = mapper;
        }

        public async Task SaveDetalles(DetalleInventarioBodegaDto[] detalleInventarioBodegaDto)
        {
            FacturaCompra factura = await _dataFacturaCompra.GetById(detalleInventarioBodegaDto.First().FacturaCompraId);

            foreach (var item in detalleInventarioBodegaDto)
            {
                BitacoraInventarioBodegaDto bitacoraInventarioBodegaDto = new BitacoraInventarioBodegaDto()
                {
                    Id = 0,
                    Activo = true,
                    CreateAt = DateTime.UtcNow.AddHours(-5),
                    Codigo = await _bitacoraInventarioBodegaBusiness.GenerarCodigo(),
                    Cantidad = item.CantidadFacturar,
                    Observacion = "",
                    DetalleInventarioBodegaId = 0,
                    EmpleadoId = item.EmpleadoId,
                    FacturaCompraId = item.FacturaCompraId,
                };

                //Consulto el inventarioDetalle
                InventarioDetalle inventarioDetalle = await _dataInventarioDetalle.GetById(item.InventarioDetalleId);
                //Consulto el insumo
                Insumo insumo = await _dataInsumo.GetById(inventarioDetalle.InsumoId);

                List<DetalleInventarioBodegaDto> detallesInventarioBodega = (List<DetalleInventarioBodegaDto>)await _data.GetDataTable(new QueryFilterDto { ForeignKey = item.InventarioDetalleId, NameForeignKey = "InventarioDetalleId" });

                if (detallesInventarioBodega.Count() > 0)
                {
                    DetalleInventarioBodegaDto detalle = detallesInventarioBodega.Find(i => i.BodegaId == item.BodegaId);

                    if (detalle != null)
                    {
                        detalle.Cantidad += item.CantidadFacturar;
                        detalle.Bodega = null!;
                        detalle.InventarioDetalle = null!;
                        await _data.Update(_mapper.Map<DetalleInventarioBodega>(detalle));

                        bitacoraInventarioBodegaDto.DetalleInventarioBodegaId = detalle.Id;
                        bitacoraInventarioBodegaDto.Observacion = $"Se agregan {item.CantidadFacturar} del {insumo.Nombre} a la bodega de la factura de compra # {factura.NumeroFactura}, Cantidad anterior: {detalle.Cantidad - item.CantidadFacturar}, Cantidad Actual: {detalle.Cantidad}";
                        
                        _ = await _bitacoraInventarioBodegaBusiness.Save(bitacoraInventarioBodegaDto);
                    }
                    else
                    {
                        DetalleInventarioBodega detalleInventarioBodega = new DetalleInventarioBodega()
                        {
                            Id = 0,
                            Activo = true,
                            CreateAt = DateTime.UtcNow.AddHours(-5),
                            Cantidad = item.CantidadFacturar,
                            BodegaId = item.BodegaId,
                            InventarioDetalleId = item.InventarioDetalleId,
                            Bodega = null!,
                            InventarioDetalle = null!,
                        };

                        _ = await _data.Save(detalleInventarioBodega);

                        bitacoraInventarioBodegaDto.DetalleInventarioBodegaId = detalleInventarioBodega.Id;
                        bitacoraInventarioBodegaDto.Observacion = $"Se agregan {item.CantidadFacturar} del {insumo.Nombre} a la bodega de la factura de compra # {factura.NumeroFactura}";

                        _ = await _bitacoraInventarioBodegaBusiness.Save(bitacoraInventarioBodegaDto);
                    }
                }
                else
                {
                    DetalleInventarioBodega detalle = new DetalleInventarioBodega()
                    {
                        Activo = true,
                        CreateAt = DateTime.UtcNow.AddHours(-5),
                        Cantidad = item.CantidadFacturar,
                        BodegaId = item.BodegaId,
                        InventarioDetalleId = item.InventarioDetalleId,
                        Bodega = null!,
                        InventarioDetalle = null!,
                    };

                    detalle = await _data.Save(detalle);

                    bitacoraInventarioBodegaDto.DetalleInventarioBodegaId = detalle.Id;
                    bitacoraInventarioBodegaDto.Observacion = $"Se agregan {item.CantidadFacturar} del {insumo.Nombre} a la bodega de la factura de compra # {factura.NumeroFactura}";

                    _ = await _bitacoraInventarioBodegaBusiness.Save(bitacoraInventarioBodegaDto);
                }
            }
        }

        public async Task UpdateDetalles(DetalleInventarioBodegaDto[] detalleInventarioBodegaDto)
        {
            foreach (DetalleInventarioBodegaDto dto in detalleInventarioBodegaDto)
            {
                dto.CreateAt = DateTime.UtcNow.AddHours(-5);
                DetalleInventarioBodega entity = _mapper.Map<DetalleInventarioBodega>(dto);
                entity.UpdateAt = DateTime.UtcNow.AddHours(-5);
                await _data.Update(entity);

                //Consulto el inventarioDetalle
                InventarioDetalle inventarioDetalle = await _dataInventarioDetalle.GetById(dto.InventarioDetalleId);
                //Consulto el insumo
                Insumo insumo = await _dataInsumo.GetById(inventarioDetalle.InsumoId);

                BitacoraInventarioBodegaDto bitacoraInventarioBodegaDto = new BitacoraInventarioBodegaDto()
                {
                    Id = 0,
                    Activo = true,
                    CreateAt = DateTime.UtcNow.AddHours(-5),
                    Codigo = await _bitacoraInventarioBodegaBusiness.GenerarCodigo(),
                    Cantidad = dto.CantidadFacturar,
                    Observacion = $"Se agregan {dto.CantidadFacturar} del insumo {insumo.Nombre} a la bodega desde el inventario.",
                    DetalleInventarioBodegaId = dto.Id,
                    EmpleadoId = dto.EmpleadoId,
                    FacturaCompraId = null!,
                };

                _ = await _bitacoraInventarioBodegaBusiness.Save(bitacoraInventarioBodegaDto);
            }
        }

        public async Task TrasladoBodegas(TrasladoBodegaDto[] lstTrasladoBodegaDto)
        {
            await Descontar(lstTrasladoBodegaDto);
            await Sumar(lstTrasladoBodegaDto);
        }

        public async Task Descontar(TrasladoBodegaDto[] lstTrasladoBodegaDto)
        {
            foreach (var item in lstTrasladoBodegaDto)
            {
                //Consulto todos los detalles con el inventarioDetalleId
                List<DetalleInventarioBodegaDto> lstDetalleInventarioBodegaDto = (List<DetalleInventarioBodegaDto>)await _data.GetDataTable(new QueryFilterDto { ForeignKey = item.InventarioDetalleId, NameForeignKey = "InventarioDetalleId" });

                //Filtro la consulta con la bodegaId
                DetalleInventarioBodegaDto detalle = lstDetalleInventarioBodegaDto.Find(i => i.BodegaId == item.BodegaId);

                if (detalle != null)
                {
                    //Consulto el detalleInventarioBodega y actualizo la cantidad
                    DetalleInventarioBodega detalleInventarioBodega = await _data.GetById(detalle.Id);
                    detalleInventarioBodega.Cantidad -= item.Cantidad;
                    await _data.Update(detalleInventarioBodega);

                    //Consulto el inventarioDetalle
                    InventarioDetalle inventarioDetalle = await _dataInventarioDetalle.GetById(detalleInventarioBodega.InventarioDetalleId);
                    //Consulto el insumo
                    Insumo insumo = await _dataInsumo.GetById(inventarioDetalle.InsumoId);

                    BitacoraInventarioBodegaDto bitacoraInventarioBodegaDto = new BitacoraInventarioBodegaDto()
                    {
                        Id = 0,
                        Activo = true,
                        CreateAt = DateTime.UtcNow.AddHours(-5),
                        Codigo = await _bitacoraInventarioBodegaBusiness.GenerarCodigo(),
                        Cantidad = item.Cantidad,
                        Observacion = $"Se descuentan {item.Cantidad} del insumo {insumo.Nombre} de la bodega del tralado de bodegas, Cantidad anterior: { detalleInventarioBodega.Cantidad + item.Cantidad }, Cantidad Actual: { detalleInventarioBodega.Cantidad }",
                        DetalleInventarioBodegaId = detalleInventarioBodega.Id,
                        EmpleadoId = item.EmpleadoId,
                        FacturaCompraId = null!,
                    };

                    _ = await _bitacoraInventarioBodegaBusiness.Save(bitacoraInventarioBodegaDto);
                }
            }
        }

        public async Task Sumar(TrasladoBodegaDto[] lstTrasladoBodegaDto)
        {
            foreach (var item in lstTrasladoBodegaDto)
            {
                //Consulto todos los detalles con el inventarioDetalleId
                List<DetalleInventarioBodegaDto> lstDetalleInventarioBodegaDto = (List<DetalleInventarioBodegaDto>)await _data.GetDataTable(new QueryFilterDto { ForeignKey = item.InventarioDetalleId, NameForeignKey = "InventarioDetalleId" });

                //Filtro la consulta con la bodegaId
                DetalleInventarioBodegaDto detalle = lstDetalleInventarioBodegaDto.Find(i => i.BodegaId == item.BodegaDestinoId);

                if (detalle != null)
                {
                    //Consulto el detalleInventarioBodega y actualizo la cantidad
                    DetalleInventarioBodega detalleInventarioBodega = await _data.GetById(detalle.Id);
                    detalleInventarioBodega.Cantidad += item.Cantidad;
                    await _data.Update(detalleInventarioBodega);

                    //Consulto el inventarioDetalle
                    InventarioDetalle inventarioDetalle = await _dataInventarioDetalle.GetById(detalleInventarioBodega.InventarioDetalleId);
                    //Consulto el insumo
                    Insumo insumo = await _dataInsumo.GetById(inventarioDetalle.InsumoId);

                    BitacoraInventarioBodegaDto bitacoraInventarioBodegaDto = new BitacoraInventarioBodegaDto()
                    {
                        Id = 0,
                        Activo = true,
                        CreateAt = DateTime.UtcNow.AddHours(-5),
                        Codigo = await _bitacoraInventarioBodegaBusiness.GenerarCodigo(),
                        Cantidad = item.Cantidad,
                        Observacion = $"Se agregan {item.Cantidad} del insumo {insumo.Nombre} a la bodega del tralado de bodegas, Cantidad anterior: {detalleInventarioBodega.Cantidad - item.Cantidad}, Cantidad Actual: {detalleInventarioBodega.Cantidad}",
                        DetalleInventarioBodegaId = detalleInventarioBodega.Id,
                        EmpleadoId = item.EmpleadoId,
                        FacturaCompraId = null!,
                    };

                    _ = await _bitacoraInventarioBodegaBusiness.Save(bitacoraInventarioBodegaDto);
                }
                else
                {
                    //Creo el inventarioDetalleBodega
                    DetalleInventarioBodega nuevoDetalle = new DetalleInventarioBodega()
                    {
                        Activo = true,
                        CreateAt = DateTime.UtcNow.AddHours(-5),
                        Cantidad = item.Cantidad,
                        BodegaId = item.BodegaDestinoId,
                        InventarioDetalleId = item.InventarioDetalleId,
                        Bodega = null!,
                        InventarioDetalle = null!,
                    };

                    nuevoDetalle = await _data.Save(nuevoDetalle);

                    //Consulto el inventarioDetalle
                    InventarioDetalle inventarioDetalle = await _dataInventarioDetalle.GetById(nuevoDetalle.InventarioDetalleId);
                    //Consulto el insumo
                    Insumo insumo = await _dataInsumo.GetById(inventarioDetalle.InsumoId);

                    BitacoraInventarioBodegaDto bitacoraInventarioBodegaDto = new BitacoraInventarioBodegaDto()
                    {
                        Id = 0,
                        Activo = true,
                        CreateAt = DateTime.UtcNow.AddHours(-5),
                        Codigo = await _bitacoraInventarioBodegaBusiness.GenerarCodigo(),
                        Cantidad = item.Cantidad,
                        Observacion = $"Se agregan {item.Cantidad} del insumo {insumo.Nombre} a la bodega del tralado de bodegas, Cantidad anterior: {nuevoDetalle.Cantidad - item.Cantidad}, Cantidad Actual: {nuevoDetalle.Cantidad}",
                        DetalleInventarioBodegaId = nuevoDetalle.Id,
                        EmpleadoId = item.EmpleadoId,
                        FacturaCompraId = null!,
                    };

                    _ = await _bitacoraInventarioBodegaBusiness.Save(bitacoraInventarioBodegaDto);
                }
            }
        }
    }
}
