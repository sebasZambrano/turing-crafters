using AutoMapper;
using Data.Interfaces.Inventory;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Inventory
{
    public class ProveedorData : BaseModelData<Proveedor, ProveedorDto>, IProveedorData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public ProveedorData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<ProveedorDto>> GetAllSelect()
        {
            try
            {
                var sql = @"SELECT
                            proveedor.Id,
                            proveedor.Activo,
                            proveedor.CreateAt,
                            proveedor.NumeroCuenta,
                            proveedor.EmpresaId,
                            proveedor.BancoId,
                            banco.Nombre AS Banco,
                            empresa.RazonSocial AS Empresa
                        FROM
                            Proveedores AS proveedor
                            INNER JOIN Empresas empresa ON proveedor.EmpresaId = empresa.Id
                            INNER JOIN Bancos banco ON proveedor.BancoId = banco.Id
                        WHERE proveedor.DeleteAt IS NULL ";

                IEnumerable<ProveedorDto> items = await _applicationContext.QueryAsync<ProveedorDto>(sql);

                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al recuperar datos: {ex.Message}");
                throw;
            }
        }

        public override async Task<IEnumerable<ProveedorDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            proveedor.Id,
                            proveedor.Activo,
                            proveedor.CreateAt,
                            proveedor.NumeroCuenta,
                            proveedor.EmpresaId,
                            proveedor.BancoId,
                            banco.Nombre AS Banco,
                            empresa.RazonSocial AS Empresa
                        FROM
                            Proveedores AS proveedor
                            INNER JOIN Empresas empresa ON proveedor.EmpresaId = empresa.Id
                            INNER JOIN Bancos banco ON proveedor.BancoId = banco.Id
                        WHERE proveedor.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND proveedor." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(empresa.RazonSocial, banco.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "proveedor.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<ProveedorDto> items = await _applicationContext.QueryAsync<ProveedorDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
