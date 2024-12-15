using AutoMapper;
using Data.Interfaces.Inventory;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Inventory
{
    public class InventarioDetalleData : BaseModelData<InventarioDetalle, InventarioDetalleDto>, IInventarioDetalleData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public InventarioDetalleData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<InventarioDetalleDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                        detalle.Id,
                        detalle.Activo,
                        detalle.CantidadTotal,
                        detalle.CantidadUsada,
                        detalle.CantidadIngresada,
                        detalle.PrecioCosto,
                        detalle.InventarioId,
                        detalle.InsumoId,
                        detalle.createAt,
                        inv.Nombre AS Inventario,
                        pro.Nombre AS Insumo,
                        detalle.CantidadTotal - COALESCE(dib.CantidadTotal, 0) AS CantidadPendienteAsignar
                    FROM
                        InventariosDetalles AS detalle
                        INNER JOIN Inventarios inv ON detalle.InventarioId = inv.Id
                        INNER JOIN Insumos pro ON detalle.InsumoId = pro.Id
                        LEFT JOIN (
                            SELECT InventarioDetalleId, SUM(Cantidad) AS CantidadTotal
                            FROM DetallesInventariosBodegas
                            WHERE DeleteAt IS NULL
                            GROUP BY InventarioDetalleId
                        ) AS dib ON dib.InventarioDetalleId = detalle.Id
                    WHERE 
                        detalle.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND detalle." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(inv.Nombre,pro.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "detalle.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<InventarioDetalleDto> items = await _applicationContext.QueryAsync<InventarioDetalleDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
