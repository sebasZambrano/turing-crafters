using AutoMapper;
using Data.Interfaces.Security;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Security;
using Entity.Models.Security;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Security
{
    public class FormularioData : BaseModelData<Formulario, FormularioDto>, IFormularioData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public FormularioData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<FormularioDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            formu.Id,
                            formu.Activo,
                            formu.CreateAt,
                            formu.Codigo,
                            formu.Nombre,
                            formu.Url,
                            formu.Icono,
                            formu.SuperAdmin,
                            formu.ModuloId,
                            mod.Nombre AS Modulo
                        FROM
                            Formularios AS formu
                        INNER JOIN Modulos mod ON formu.ModuloId = mod.Id
                        WHERE formu.DeleteAt IS NULL ";


            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND formu." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(formu.Nombre, mod.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "formu.Id") + " " + (filters.DirectionOrder ?? "asc");
            }
        
            IEnumerable<FormularioDto> items = await _applicationContext.QueryAsync<FormularioDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
