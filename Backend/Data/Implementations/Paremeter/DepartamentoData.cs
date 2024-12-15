using AutoMapper;
using Data.Interfaces.Parameter;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Paremeter
{
    public class DepartamentoData : BaseModelData<Departamento, DepartamentoDto>, IDepartamentoData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public DepartamentoData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<DepartamentoDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            dep.Id,
                            dep.Activo,
                            dep.CreateAt,
                            dep.Codigo,
                            dep.Nombre,
                            dep.PaisId,
                            pais.Nombre AS Pais
                        FROM
                            Departamentos AS dep
                        INNER JOIN Paises pais ON dep.PaisId = pais.Id
                        WHERE dep.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND dep." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(dep.Codigo, dep.Nombre, pais.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "dep.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<DepartamentoDto> items = await _applicationContext.QueryAsync<DepartamentoDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
