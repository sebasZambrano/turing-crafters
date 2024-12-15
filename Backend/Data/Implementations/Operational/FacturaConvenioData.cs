using AutoMapper;
using Data.Interfaces.Operational;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Operational
{
    public class FacturaConvenioData : BaseModelData<FacturaConvenio, FacturaConvenioDto>, IFacturaConvenioData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public FacturaConvenioData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<FacturaConvenioDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            facturaConvenio.Id,
                            facturaConvenio.Activo,
                            facturaConvenio.CreateAt,
                            facturaConvenio.FacturaId,
                            factura.NumeroFactura AS Factura,
                            facturaConvenio.ConvenioId,
                            convenio.Nombre AS Convenio
                        FROM
                            FacturasConvenios AS facturaConvenio
                        INNER JOIN Facturas factura ON facturaConvenio.FacturaId = factura.Id
                        INNER JOIN Convenios convenio ON facturaConvenio.ConvenioId = convenio.Id
                        WHERE facturaConvenio.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND facturaConvenio." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(factura.NumeroFactura, convenio.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "facturaConvenio.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<FacturaConvenioDto> items = await _applicationContext.QueryAsync<FacturaConvenioDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
