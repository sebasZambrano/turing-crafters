using AutoMapper;
using Data.Interfaces.Parameter;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Paremeter
{
    public class EmpleadoData : BaseModelData<Empleado, EmpleadoDto>, IEmpleadoData
    {
        protected readonly ApplicationDbContext _applicationContext;
        public EmpleadoData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<EmpleadoDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            empleado.Id,
                            empleado.Activo,
                            empleado.CreateAt,
                            empleado.Codigo,
                            empleado.PersonaId,
                            CONCAT(persona.PrimerNombre, ' ', persona.PrimerApellido) AS Persona,
                            empleado.CargoId,
                            cargo.Nombre AS Cargo,
                            empleado.EmpresaId,
                            empresa.RazonSocial AS Empresa,
                            empleado.CajaId,
                            caja.Nombre AS Caja
                        FROM
                            Empleados AS empleado
                        INNER JOIN Personas persona ON empleado.PersonaId = persona.Id
                        INNER JOIN Cargos cargo ON empleado.CargoId = cargo.Id
                        INNER JOIN Empresas empresa ON empleado.EmpresaId = empresa.Id
                        INNER JOIN Cajas caja ON empleado.CajaId = caja.Id
                        WHERE empleado.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND empleado." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT()) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "empleado.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<EmpleadoDto> items = await _applicationContext.QueryAsync<EmpleadoDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
