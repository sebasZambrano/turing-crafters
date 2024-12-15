using AutoMapper;
using Data.Interfaces.Parameter;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Paremeter
{
    public class CategoriaData : BaseModelData<Categoria, CategoriaDto>, ICategoriaData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public CategoriaData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<CategoriaDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            cat.Id,
                            cat.Activo,
                            cat.CreateAt,
                            cat.Codigo,
                            cat.Nombre,
                            cat.MacroCategoriaId,
                            macro.Nombre AS MacroCategoria
                        FROM
                            Categorias AS cat
                        INNER JOIN MacroCategorias macro ON cat.MacroCategoriaId = macro.Id
                        WHERE cat.DeleteAt IS NULL ";


            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND cat." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(cat.Codigo,cat.Nombre,macro.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "cat.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<CategoriaDto> items = await _applicationContext.QueryAsync<CategoriaDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
