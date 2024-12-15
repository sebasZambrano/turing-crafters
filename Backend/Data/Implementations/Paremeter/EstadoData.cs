using AutoMapper;
using Data.Interfaces.Parameter;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Paremeter
{
    public class EstadoData : BaseModelData<Estado, EstadoDto>, IEstadoData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public EstadoData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<EstadoDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            est.Id,
                            est.Activo,
                            est.CreateAt,
                            est.Codigo,
                            est.Nombre,
                            est.TipoEstadoId,
                            tipo.Nombre AS TipoEstado
                        FROM
                            Estados AS est
                        INNER JOIN TiposEstados tipo ON est.TipoEstadoId = tipo.Id
                        WHERE est.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND est." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(est.Codigo, est.Nombre, tipo.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "est.Id") + " " + (filters.DirectionOrder ?? "asc");
            }
        
            IEnumerable<EstadoDto> items = await _applicationContext.QueryAsync<EstadoDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
