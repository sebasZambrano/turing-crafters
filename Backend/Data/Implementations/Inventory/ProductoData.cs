using AutoMapper;
using Data.Interfaces.Inventory;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Inventory
{
    public class ProductoData : BaseModelData<Producto, ProductoDto>, IProductoData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public ProductoData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<ProductoDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            pro.Id,
                            pro.Codigo,
                            pro.Nombre,
                            pro.Activo,
                            pro.DescripcionCorta,
                            pro.DescripcionLarga,
                            pro.Precio,
                            pro.PrecioCosto,
                            pro.Descuento,
                            pro.Iva,
                            pro.CategoriaId,
                            pro.createAt,
                            cat.Nombre AS Categoria
                        FROM
                            Productos AS pro
                            INNER JOIN Categorias cat ON pro.CategoriaId = cat.Id
                        WHERE pro.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND pro." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(pro.Codigo, pro.Nombre, cat.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "pro.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<ProductoDto> items = await _applicationContext.QueryAsync<ProductoDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
