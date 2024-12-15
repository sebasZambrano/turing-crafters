using AutoMapper;
using Data.Interfaces.Security;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Security;
using Entity.Models.Security;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Security
{
    public class UsuarioRolData : BaseModelData<UsuarioRol, UsuarioRolDto>, IUsuarioRolData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public UsuarioRolData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<UsuarioRolDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                                usuRol.Id,                                
                                usuRol.RolId,                                
                                usuRol.UsuarioId,
                                usuRol.Activo,
                                usuRol.createAt,                                
                                usu.UserName AS Usuario,
                                rol.Nombre AS Rol
                            FROM UsuariosRoles AS usuRol
                            INNER JOIN Usuarios usu ON usuRol.UsuarioId = usu.Id                             
                            INNER JOIN Roles rol ON usuRol.RolId = rol.Id                       
                            WHERE usuRol.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND usuRol." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(usu.UserName, rol.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "usu.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<UsuarioRolDto> items = await _applicationContext.QueryAsync<UsuarioRolDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey});

            return items;
        }

    }
}

