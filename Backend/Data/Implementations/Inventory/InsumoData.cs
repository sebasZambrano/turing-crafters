using AutoMapper;
using Data.Interfaces.Inventory;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Inventory
{
    public class InsumoData : BaseModelData<Insumo, InsumoDto>, IInsumoData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public InsumoData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<InsumoDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            insumos.Id,
                            insumos.Activo,
                            insumos.CreateAt,
                            insumos.Codigo,
                            insumos.Nombre,
                            insumos.Descripcion,
                            insumos.UnidadMedidaId,
                            unidad.Nombre AS UnidadMedida
                        FROM
                            Insumos AS insumos
                        INNER JOIN UnidadesMedidas unidad ON insumos.UnidadMedidaId = unidad.Id
                        WHERE insumos.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND insumos." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(insumos.Codigo, insumos.Nombre, insumos.Descripcion)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "insumos.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<InsumoDto> items = await _applicationContext.QueryAsync<InsumoDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
