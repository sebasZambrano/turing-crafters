using AutoMapper;
using Data.Interfaces.Operational;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Operational
{
    public class NotaCreditoDetalleData : BaseModelData<NotaCreditoDetalle, NotaCreditoDetalleDto>, INotaCreditoDetalleData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public NotaCreditoDetalleData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<NotaCreditoDetalleDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            detalle.Id,
                            detalle.Activo,
                            detalle.CreateAt,
                            detalle.NotaCreditoId,
                            nota.Codigo AS NotaCredito,
                            detalle.FacturaDetalleId,
                            facturaDetalle.Codigo AS FacturaDetalle,
                            detalle.Cantidad,
                            facturaDetalle.Codigo AS Codigo,
                            pro.Nombre AS Producto,
                            pro.Id AS ProductoId,
                            facturaDetalle.PrecioProducto AS PrecioProducto
                        FROM
                            NotasCreditosDetalles AS detalle
                        INNER JOIN NotasCreditos nota ON detalle.NotaCreditoId = nota.Id
                        INNER JOIN FacturasDetalles facturaDetalle ON detalle.FacturaDetalleId = facturaDetalle.Id
                        INNER JOIN Productos pro ON facturaDetalle.ProductoId = pro.Id
                        WHERE detalle.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND detalle." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(nota.Codigo, facturaDetalle.Codigo, pro.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "detalle.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<NotaCreditoDetalleDto> items = await _applicationContext.QueryAsync<NotaCreditoDetalleDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
