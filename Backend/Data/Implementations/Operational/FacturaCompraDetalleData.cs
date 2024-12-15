using AutoMapper;
using Data.Interfaces.Operational;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Operational
{
    public class FacturaCompraDetalleData : BaseModelData<FacturaCompraDetalle, FacturaCompraDetalleDto>, IFacturaCompraDetalleData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public FacturaCompraDetalleData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<FacturaCompraDetalleDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            detalle.Id,
                            detalle.Activo,
                            detalle.CreateAt,
                            detalle.Codigo,
                            detalle.Cantidad,
                            detalle.SubTotal,
                            detalle.PrecioCosto,
                            detalle.Descuento,
                            detalle.Iva,
                            detalle.FacturaCompraId,
                            factura.NumeroFactura AS FacturaCompra,
                            detalle.InsumoId,
                            Insumo.Nombre AS Insumo
                        FROM
                            FacturasComprasDetalles AS detalle
                        INNER JOIN Insumos Insumo ON detalle.InsumoId = Insumo.Id
                        INNER JOIN FacturasCompras factura ON detalle.FacturaCompraId = factura.Id
                        WHERE detalle.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND detalle." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(detalle.Codigo, factura.NumeroFactura, Insumo.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "detalle.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<FacturaCompraDetalleDto> items = await _applicationContext.QueryAsync<FacturaCompraDetalleDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
