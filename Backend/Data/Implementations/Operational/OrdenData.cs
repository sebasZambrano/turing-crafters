using AutoMapper;
using Data.Interfaces.Operational;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Operational
{
    public class OrdenData : BaseModelData<Orden, OrdenDto>, IOrdenData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public OrdenData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<OrdenDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            orden.Id,
                            orden.Activo,
                            orden.CreateAt,
                            orden.Codigo,
                            orden.Descripcion,
                            orden.CantidadPersonas,
                            orden.Total,
                            orden.MesaId,
                            mesa.Nombre AS Mesa,
                            orden.EmpleadoId,
                            CONCAT(perEmpleado.PrimerNombre, ' ', perEmpleado.PrimerApellido) AS Empleado,
                            orden.EstadoId,
                            estado.Nombre AS Estado
                        FROM
                            Ordenes AS orden
                        INNER JOIN Empleados empleado ON orden.EmpleadoId = empleado.Id
                        INNER JOIN Mesas mesa ON orden.MesaId = mesa.Id
                        INNER JOIN Estados estado ON orden.EstadoId = estado.Id
                        INNER JOIN Personas perEmpleado ON empleado.PersonaId = perEmpleado.Id
                        WHERE orden.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND orden." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(orden.Codigo, perEmpleado.PrimerNombre, perEmpleado.PrimerApellido, mesa.Nombre, estado.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "orden.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<OrdenDto> items = await _applicationContext.QueryAsync<OrdenDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
