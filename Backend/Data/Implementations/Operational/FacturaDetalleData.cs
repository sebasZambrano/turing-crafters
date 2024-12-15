using AutoMapper;
using Data.Interfaces.Operational;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Operational
{
    public class FacturaDetalleData : BaseModelData<FacturaDetalle, FacturaDetalleDto>, IFacturaDetalleData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public FacturaDetalleData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<FacturaDetalleDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            detalle.Id,
                            detalle.Activo,
                            detalle.CreateAt,
                            detalle.Codigo,
                            detalle.Cantidad,
                            detalle.SubTotal,
                            detalle.PrecioProducto,
                            detalle.Descuento,
                            detalle.Iva,
                            detalle.FacturaId,
                            factura.NumeroFactura AS Factura,
                            detalle.ProductoId,
                            pro.Nombre AS Producto
                        FROM
                            FacturasDetalles AS detalle
                        INNER JOIN Facturas factura ON detalle.FacturaId = factura.Id
                        INNER JOIN Productos pro ON detalle.ProductoId = pro.Id
                        WHERE detalle.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND detalle." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.FechaInicio) && !string.IsNullOrEmpty(filters.FechaFin))
            {
                sql += @"AND detalle.CreateAt BETWEEN @FechaInicio AND @FechaFin ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(factura.NumeroFactura, pro.Nombre, bodega.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "detalle.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<FacturaDetalleDto> items = await _applicationContext.QueryAsync<FacturaDetalleDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey, FechaInicio = filters.FechaInicio, FechaFin = filters.FechaFin });

            return items;
        }

        public async Task SaveDetalles(FacturaDetalle[] facturasDetalles)
        {
            _applicationContext.AddRange(facturasDetalles);
            await _applicationContext.SaveChangesAsync();
        }
    }
}
