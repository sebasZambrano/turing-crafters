using AutoMapper;
using Data.Interfaces.Parameter;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Paremeter
{
    public class CajaData : BaseModelData<Caja, CajaDto>, ICajaData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public CajaData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<CajaDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            caja.Id,
                            caja.Activo,
                            caja.CreateAt,
                            caja.Codigo,
                            caja.Nombre,
                            caja.BodegaId,
                            bodega.Nombre AS Bodega
                        FROM
                            Cajas AS caja
                        INNER JOIN Bodegas bodega ON caja.BodegaId = bodega.Id
                        WHERE caja.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND caja." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(caja.Codigo,caja.Nombre, bodega.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "caja.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<CajaDto> items = await _applicationContext.QueryAsync<CajaDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
