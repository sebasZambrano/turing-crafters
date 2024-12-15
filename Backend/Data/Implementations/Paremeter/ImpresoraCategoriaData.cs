using AutoMapper;
using Data.Interfaces.Parameter;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Paremeter
{
    public class ImpresoraCategoriaData : BaseModelData<ImpresoraCategoria, ImpresoraCategoriaDto>, IImpresoraCategoriaData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public ImpresoraCategoriaData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<ImpresoraCategoriaDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            impresoraCategoria.Id,
                            impresoraCategoria.Activo,
                            impresoraCategoria.CreateAt,
                            impresoraCategoria.CategoriaId,
                            impresoraCategoria.ImpresoraId,
                            impresoraCategoria.SalonId,
                            categoria.Nombre AS Categoria,
                            impresora.Nombre AS Impresora,
                            salon.Nombre AS Salon
                        FROM
                            ImpresorasCategorias AS impresoraCategoria
                        INNER JOIN Categorias categoria ON impresoraCategoria.CategoriaId = categoria.Id
                        INNER JOIN Impresoras impresora ON impresoraCategoria.ImpresoraId = impresora.Id
                        INNER JOIN Salones salon ON impresoraCategoria.SalonId = salon.Id
                        WHERE impresoraCategoria.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND impresoraCategoria." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(impresora.Nombre,categoria.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "impresoraCategoria.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<ImpresoraCategoriaDto> items = await _applicationContext.QueryAsync<ImpresoraCategoriaDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
