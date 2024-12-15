using AutoMapper;
using Data.Interfaces.Security;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Security;
using Entity.Models.Security;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Security
{
    public class UsuarioData : BaseModelData<Usuario, UsuarioDto>, IUsuarioData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public UsuarioData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<UsuarioDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            usu.Id,
                            usu.UserName,
                            usu.Password,                            
                            usu.PersonaId,
                            usu.Activo,
                            usu.createAt,
                            CONCAT(per.PrimerNombre,' ', per.PrimerApellido) AS Persona
                        FROM
                            Usuarios AS usu
                        INNER JOIN Personas per ON usu.PersonaId = per.Id                       
                        WHERE usu.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND usu." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(usu.UserName,per.PrimerNombre, per.SegundoNombre, per.PrimerApellido, per.SegundoApellido)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "usu.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<UsuarioDto> items = await _applicationContext.QueryAsync<UsuarioDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey});

            return items;
        }

        public async Task<UsuarioDto> GetByUserName(string userName)
        {
            var sql = @"SELECT
                            usu.Id,
                            usu.UserName,
                            usu.Password,                            
                            usu.Activo,
                            usu.PersonaId,
                            CONCAT(per.PrimerNombre,' ', per.PrimerApellido)  as Persona
                        FROM
                            Usuarios AS usu
                        INNER JOIN Personas per ON usu.PersonaId = per.Id
                        WHERE usu.UserName = @username AND usu.DeleteAt IS NULL";
            return await _applicationContext.QueryFirstOrDefaultAsync<UsuarioDto>(sql, new { username = userName });
        }

        public async Task<IEnumerable<MenuDto>> GetDataMenu()
        {
            var sql = "SELECT Id as ModuloId, Nombre, Icono FROM Modulos WHERE DeleteAt IS NULL ORDER BY Nombre ASC";

            return await _applicationContext.QueryAsync<MenuDto>(sql);
        }

        public async Task<IEnumerable<FormularioDto>> GetFormularioMenu(int usuarioId, int? moduloId)
        {
            var sql = @"SELECT
	                        form.Nombre,
                            form.Url,
                            form.Icono
                        FROM UsuariosRoles urol
                        INNER JOIN FormulariosRoles rfor ON rfor.RolId = urol.RolId
                        INNER JOIN Formularios form ON form.Id = rfor.FormularioId
                        INNER JOIN Modulos smod ON smod.Id = form.ModuloId
                        WHERE urol.DeleteAt IS NULL AND urol.UsuarioId = @UsuarioId ";

            if (moduloId == null)
            {
                sql += @" AND form.ModuloId IS NULL";
            }
            else
            {
                sql += @" AND form.ModuloId = @ModuloPadreId";
            }

            sql += @" AND form.DeleteAt IS NULL AND smod.DeleteAt IS NULL
                    GROUP BY form.Nombre, form.Url, form.Icono
                    ORDER BY form.Nombre asc";
            return await _applicationContext.QueryAsync<FormularioDto>(sql, new { UsuarioId = usuarioId, ModuloPadreId = moduloId });
        }
    }
}

