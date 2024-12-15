using AutoMapper;
using Data.Interfaces.Operational;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Operational
{
    public class OrdenDetalleData : BaseModelData<OrdenDetalle, OrdenDetalleDto>, IOrdenDetalleData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public OrdenDetalleData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<OrdenDetalleDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            ordenDetalle.Id,
                            ordenDetalle.Activo,
                            ordenDetalle.CreateAt,
                            ordenDetalle.Codigo,
                            ordenDetalle.Cantidad,
                            ordenDetalle.Precio,
                            ordenDetalle.Observaciones,
                            ordenDetalle.UpdateAt,
                            ordenDetalle.OrdenId,
                            orden.Codigo AS Orden,
                            ordenDetalle.ProductoId,
                            producto.Nombre AS Producto,
                            ordenDetalle.EstadoId,
                            estado.Nombre AS Estado
                        FROM
                            OrdenesDetalles AS ordenDetalle
                        INNER JOIN Estados estado ON ordenDetalle.EstadoId = estado.Id
                        INNER JOIN Ordenes orden ON ordenDetalle.OrdenId = orden.Id
                        INNER JOIN Productos producto ON ordenDetalle.ProductoId = producto.Id
                        WHERE ordenDetalle.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND ordenDetalle." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(ordenDetalle.Codigo, orden.Codigo, producto.Nombre, estado.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "ordenDetalle.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<OrdenDetalleDto> items = await _applicationContext.QueryAsync<OrdenDetalleDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }

        public async Task SaveDetalles(OrdenDetalle[] detalles)
        {
            _applicationContext.AddRange(detalles);
            await _applicationContext.SaveChangesAsync();
        }
    }
}
