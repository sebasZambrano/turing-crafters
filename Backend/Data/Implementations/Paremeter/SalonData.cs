using AutoMapper;
using Data.Interfaces.Parameter;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Paremeter
{
    public class SalonData : BaseModelData<Salon, SalonDto>, ISalonData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public SalonData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<SalonDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            salon.Id,
                            salon.Activo,
                            salon.CreateAt,
                            salon.Codigo,
                            salon.Nombre,
                            salon.Descripcion,
                            salon.ZonaId,
                            zona.Nombre AS Zona
                        FROM
                            Salones AS salon
                        INNER JOIN Zonas zona ON salon.ZonaId = zona.Id
                        WHERE salon.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND salon." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(zona.Nombre, salon.Codigo, salon.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "salon.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<SalonDto> items = await _applicationContext.QueryAsync<SalonDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
