using AutoMapper;
using Data.Interfaces.Security;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Security;
using Entity.Models.Security;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Security
{
    public class FormularioRolData : BaseModelData<FormularioRol, FormularioRolDto>, IFormularioRolData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public FormularioRolData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<FormularioRolDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            formuRol.Id,
                            formuRol.Activo,
                            formuRol.CreateAt,
                            formuRol.FormularioId,
                            formuRol.RolId,
                            formu.Nombre AS Formulario,
                            rol.Nombre AS Rol
                        FROM
                            FormulariosRoles AS formuRol
                        INNER JOIN Formularios formu ON formuRol.FormularioId = formu.Id
                        INNER JOIN Roles rol ON formuRol.RolId = rol.Id
                        WHERE formuRol.DeleteAt IS NULL ";


            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND formuRol." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(formu.Nombre, rol.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "formuRol.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<FormularioRolDto> items = await _applicationContext.QueryAsync<FormularioRolDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
