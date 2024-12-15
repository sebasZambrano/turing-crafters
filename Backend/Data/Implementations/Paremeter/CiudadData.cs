using AutoMapper;
using Data.Interfaces.Parameter;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Paremeter
{
    public class CiudadData : BaseModelData<Ciudad, CiudadDto>, ICiudadData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public CiudadData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<CiudadDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            ciu.Id,
                            ciu.Activo,
                            ciu.CreateAt,
                            ciu.Codigo,
                            ciu.Nombre,
                            ciu.DepartamentoId,
                            dep.Nombre AS Departamento
                        FROM
                            Ciudades AS ciu
                        INNER JOIN Departamentos dep ON ciu.DepartamentoId = dep.Id
                        WHERE ciu.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND ciu." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(ciu.Codigo,ciu.Nombre, dep.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "ciu.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<CiudadDto> items = await _applicationContext.QueryAsync<CiudadDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
