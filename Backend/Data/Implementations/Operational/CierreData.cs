using AutoMapper;
using Data.Interfaces.Operational;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Operational
{
    public class CierreData : BaseModelData<Cierre, CierreDto>, ICierreData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public CierreData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<CierreDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            cierre.Id,
                            cierre.Activo,
                            cierre.CreateAt,
                            cierre.FechaInicial,
                            cierre.FechaFinal,
                            cierre.TotalIngreso,
                            cierre.TotalEgreso,
                            cierre.SaldoCaja,
                            cierre.SaldoEmpleado,
                            cierre.Base,
                            cierre.Observacion,
                            cierre.EmpleadoId,
                            CONCAT(perEmpleado.PrimerNombre, ' ', perEmpleado.PrimerApellido) AS Empleado
                        FROM
                            Cierres AS cierre
                        INNER JOIN Empleados empleado ON cierre.EmpleadoId = empleado.Id
                        INNER JOIN Personas perEmpleado ON empleado.PersonaId = perEmpleado.Id
                        WHERE cierre.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND cierre." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(perEmpleado.PrimerNombre, perEmpleado.PrimerApellido)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "cierre.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<CierreDto> items = await _applicationContext.QueryAsync<CierreDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
