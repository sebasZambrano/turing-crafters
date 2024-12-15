using AutoMapper;
using Data.Interfaces.Inventory;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Inventory
{
    public class DetalleInventarioBodegaData : BaseModelData<DetalleInventarioBodega, DetalleInventarioBodegaDto>, IDetalleInventarioBodegaData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public DetalleInventarioBodegaData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<DetalleInventarioBodegaDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            detalle.Id,
                            detalle.Activo,
                            detalle.CreateAt,
                            detalle.Cantidad,
                            detalle.BodegaId,
                            bodega.Nombre AS Bodega,
                            detalle.InventarioDetalleId,
                            pro.Nombre AS InventarioDetalle
                        FROM
                            DetallesInventariosBodegas AS detalle
                            INNER JOIN Bodegas bodega ON detalle.BodegaId = bodega.Id
                            INNER JOIN InventariosDetalles invDet ON detalle.InventarioDetalleId = invDet.Id
                            INNER JOIN Insumos pro ON invDet.InsumoId = pro.Id
                        WHERE detalle.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND detalle." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(pro.Nombre, bodega.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "detalle.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<DetalleInventarioBodegaDto> items = await _applicationContext.QueryAsync<DetalleInventarioBodegaDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
