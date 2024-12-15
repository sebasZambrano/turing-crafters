using AutoMapper;
using Business.Interfaces.Inventory;
using Data.Interfaces;
using Data.Interfaces.Inventory;
using Data.Interfaces.Parameter;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Dtos.Parameter;
using Entity.Models.Inventory;
using Entity.Models.Parameter;

namespace Business.Implementations.Inventory
{
    public class ProductoBusiness : BaseModelBusiness<Producto, ProductoDto>, IProductoBusiness
    {
        private readonly IProductoData _data;
        private readonly IInventarioDetalleData _dataInventarioDetalle;
        private readonly IBitacoraInventarioData _dataBitacoraInventario;
        private readonly IInsumoData _dataInsumo;
        private readonly IInsumoProductoData _dataInsumoProducto;
        private readonly ICategoriaData _dataCategoria;
        private readonly IBaseModelData<Inventario, InventarioDto> _dataInventario;
        private readonly IBaseModelData<UnidadMedida, UnidadMedidaDto> _dataUnidadMedida;
        private readonly IBitacoraInventarioBusiness _businessBitacoraInventario;
        private readonly IMapper _mapper;

        public ProductoBusiness(IProductoData data, IInsumoData dataInsumo, IInventarioDetalleData dataInventarioDetalle,
            IBitacoraInventarioData dataBitacoraInventario, IInsumoProductoData dataInsumoProducto,
            IBaseModelData<Inventario, InventarioDto> dataInventario,
            ICategoriaData dataCategoria,
            IBaseModelData<UnidadMedida, UnidadMedidaDto> dataUnidadMedida,
            IBitacoraInventarioBusiness businessBitacoraInventario, IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _dataInsumo = dataInsumo;
            _dataInsumoProducto = dataInsumoProducto;
            _dataInventario = dataInventario;
            _dataCategoria = dataCategoria;
            _dataInventarioDetalle = dataInventarioDetalle;
            _dataUnidadMedida = dataUnidadMedida;
            _dataBitacoraInventario = dataBitacoraInventario;
            _businessBitacoraInventario = businessBitacoraInventario;
            _mapper = mapper;
        }

        public override async Task<ProductoDto> Save(ProductoDto dto)
        {
            //Creo el producto
            dto.Codigo = await GenerarCodigo(dto);
            dto.CreateAt = DateTime.UtcNow.AddHours(-5);
            Producto producto = _mapper.Map<Producto>(dto);
            producto = await _data.Save(producto);

            if (dto.Insumo)
            {
                //Creo el insumo y lo asocio con el producto
                dto.Id = producto.Id;
                await SaveInsumoProducto(dto);

                //Consulto el inventario
                Inventario inventario = await _dataInventario.GetByCode("DEFAULT");

                //Consulto el insumo
                IEnumerable<InsumoProductoDto> insumoProducto = await _dataInsumoProducto.GetDataTable(new QueryFilterDto() { ForeignKey = producto.Id, NameForeignKey = "ProductoId" });

                //Creo el inventario detalle
                InventarioDetalle inventarioDetalle = new InventarioDetalle()
                {
                    Activo = producto.Activo,
                    CreateAt = DateTime.UtcNow.AddHours(-5),
                    CantidadTotal = 0,
                    CantidadUsada = 0,
                    CantidadIngresada = 0,
                    PrecioCosto = producto.PrecioCosto,
                    InventarioId = inventario.Id,
                    InsumoId = insumoProducto.First().InsumoId,
                    Inventario = null!,
                    Insumo = null!,
                };

                _ = await _dataInventarioDetalle.Save(inventarioDetalle);

                //Creo la bitacora de inventario
                BitacoraInventario bitacoraInventario = new BitacoraInventario()
                {
                    Codigo = await _businessBitacoraInventario.GenerarCodigo(),
                    Cantidad = 0,
                    Observacion = $"Se agrega el Insumo: {insumoProducto.First().Insumo} al inevntario con cantidades en 0",
                    EmpleadoId = dto.EmpleadoId,
                    InsumoId = insumoProducto.First().InsumoId,
                    Activo = true,
                    CreateAt = DateTime.UtcNow.AddHours(-5),
                    Empleado = null!,
                    Insumo = null!,
                };

                _ = await _dataBitacoraInventario.Save(bitacoraInventario);
            }

            return _mapper.Map<ProductoDto>(producto);
        }

        public override async Task Update(ProductoDto dto)
        {
            Producto producto = await _data.GetById(dto.Id);

            if (dto.Insumo)
            {
                IEnumerable<InsumoProductoDto> lstInsumoProducto = await _dataInsumoProducto.GetDataTable(new QueryFilterDto() { ForeignKey = dto.Id, NameForeignKey = "ProductoId" });
                if (lstInsumoProducto.Count() > 0)
                {
                    //Actualizo el insumo que coincida con el codigo del producto
                    foreach (var item in lstInsumoProducto)
                    {
                        Insumo insumo = await _dataInsumo.GetById(item.InsumoId);
                        if (insumo.Codigo == $"INS-{producto.Codigo}")
                        {
                            insumo.Nombre = dto.Nombre;
                            insumo.Activo = dto.Activo;
                            insumo.Descripcion = dto.DescripcionCorta;
                            insumo.UpdateAt = DateTime.UtcNow.AddHours(-5);
                            await _dataInsumo.Update(insumo);
                        }

                    }
                }
                else
                {
                    //Creo el insumo y lo asocio con el producto
                    await SaveInsumoProducto(dto);
                }
            }

            //Actualizo el producto
            producto.Nombre = dto.Nombre;
            producto.Activo = dto.Activo;
            producto.Descuento = dto.Descuento;
            producto.Iva = dto.Iva;
            producto.DescripcionCorta = dto.DescripcionCorta;
            producto.DescripcionLarga = dto.DescripcionLarga;
            producto.Precio = dto.Precio;
            producto.PrecioCosto = dto.PrecioCosto;
            producto.CategoriaId = dto.CategoriaId;
            producto.UpdateAt = DateTime.UtcNow.AddHours(-5);
            await _data.Update(producto);
        }

        public async Task SaveInsumoProducto(ProductoDto producto)
        {
            //Consulto la unidad de medida
            UnidadMedida unidadMedida = await _dataUnidadMedida.GetByCode("U");

            //Creo el insumo
            Insumo insumo = new Insumo()
            {
                Codigo = $"INS-{producto.Codigo}",
                Nombre = producto.Nombre,
                Activo = producto.Activo,
                CreateAt = producto.CreateAt,
                Descripcion = producto.DescripcionCorta,
                UnidadMedidaId = unidadMedida.Id,
                UnidadMedida = null!,
            };

            insumo = await _dataInsumo.Save(insumo);

            //Creo el InsumoProducto
            InsumoProducto insumoProducto = new InsumoProducto()
            {
                Adicional = false,
                Cantidad = 1,
                InsumoId = insumo.Id,
                ProductoId = producto.Id,
                UnidadMedidaId = insumo.UnidadMedidaId,
                Activo = producto.Activo,
                CreateAt = producto.CreateAt,
                Insumo = null!,
                Producto = null!,
                UnidadMedida = null!,
            };

            insumoProducto = await _dataInsumoProducto.Save(insumoProducto);
        }

        public async Task<string> GenerarCodigo(ProductoDto producto)
        {
            Categoria categoria = await _dataCategoria.GetById(producto.CategoriaId);
            IEnumerable<ProductoDto> CategoriasProductos = await _data.GetDataTable(new QueryFilterDto { ForeignKey = categoria.Id, NameForeignKey = "CategoriaId" });
            int cantidadProductos = CategoriasProductos.Count() + 1;

            //Consulto si ya hay un producto con este codigo
            Producto pro = await _data.GetByCode($"{categoria.Codigo}{cantidadProductos}");
            string codigo = "";
            if (pro == null)
            {
                codigo = $"{categoria.Codigo}{cantidadProductos}";
            }
            else
            {
                codigo = $"{categoria.Codigo}{cantidadProductos + 1}";
            }

            return codigo;
        }
    }
}
