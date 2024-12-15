using AutoMapper;
using Data.Interfaces.Operational;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Operational
{
    public class BitacoraFacturaData : BaseModelData<BitacoraFactura, BitacoraFacturaDto>, IBitacoraFacturaData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public BitacoraFacturaData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<BitacoraFacturaDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            bit.Id,
                            bit.Activo,
                            bit.CreateAt,
                            bit.Codigo,
                            bit.Cantidad,
                            bit.Observacion,
                            bit.EmpleadoId,
                            bit.FacturaId,
                            bit.InsumoId,
                            insumo.Nombre AS Insumo,
                            CONCAT(per.PrimerNombre, ' ', per.PrimerApellido) AS Empleado,
                            fact.NumeroFactura AS Factura
                        FROM
                            BitacorasFacturas AS bit
                            INNER JOIN Empleados emp ON bit.EmpleadoId = emp.Id
                            INNER JOIN Facturas fact ON bit.FacturaId = fact.Id
                            INNER JOIN Insumos insumo ON bit.InsumoId = insumo.Id
                            LEFT JOIN Personas per ON emp.PersonaId = per.Id
                        WHERE bit.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND bit." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(bit.Codigo, fact.Nombre, per.PrimerNombre, per.PrimerApellido)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "bit.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<BitacoraFacturaDto> items = await _applicationContext.QueryAsync<BitacoraFacturaDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
