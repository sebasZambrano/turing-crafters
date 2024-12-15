using AutoMapper;
using Data.Interfaces.Inventory;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Inventory
{
    public class InsumoProductoData : BaseModelData<InsumoProducto, InsumoProductoDto>, IInsumoProductoData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public InsumoProductoData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<InsumoProductoDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            insumoProducto.Id,
                            insumoProducto.Activo,
                            insumoProducto.CreateAt,
                            insumoProducto.Adicional,
                            insumoProducto.Cantidad,
                            insumoProducto.InsumoId,
                            insumo.Nombre AS Insumo,
                            insumoProducto.ProductoId,
                            producto.Nombre AS Producto,
                            insumoProducto.UnidadMedidaId,
                            unidad.Nombre AS UnidadMedida
                        FROM
                            InsumosProductos AS insumoProducto
                        INNER JOIN Insumos insumo ON insumoProducto.InsumoId = insumo.Id
                        INNER JOIN Productos producto ON insumoProducto.ProductoId = producto.Id
                        INNER JOIN UnidadesMedidas unidad ON insumoProducto.UnidadMedidaId = unidad.Id
                        WHERE insumoProducto.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND insumoProducto." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(insumo.Nombre, producto.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "insumoProducto.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<InsumoProductoDto> items = await _applicationContext.QueryAsync<InsumoProductoDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }

        public async Task<IEnumerable<DetalleInventarioBodegaDto>> GetOrdenDetalle(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            detalleBodega.Id AS Id,
                            detalleBodega.Cantidad,
                            detalleBodega.BodegaId,
                            bodega.Nombre AS Bodega,
                            detalleBodega.InventarioDetalleId,
                            insumo.Nombre AS Insumo
                        FROM
                            InsumosProductos AS insumoPro
                        INNER JOIN InventariosDetalles AS detalle ON insumoPro.InsumoId = detalle.InsumoId
                        INNER JOIN DetallesInventariosBodegas AS detalleBodega ON detalle.Id = detalleBodega.InventarioDetalleId
                        INNER JOIN Bodegas AS bodega ON detalleBodega.BodegaId = bodega.Id
                        INNER JOIN Insumos AS insumo ON insumoPro.InsumoId = insumo.Id
                        WHERE insumoPro.DeleteAt IS NULL AND insumoPro.ProductoId = @foreignKey AND detalleBodega.Cantidad >= 1";

            IEnumerable<DetalleInventarioBodegaDto> items = await _applicationContext.QueryAsync<DetalleInventarioBodegaDto>(sql, new { foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
