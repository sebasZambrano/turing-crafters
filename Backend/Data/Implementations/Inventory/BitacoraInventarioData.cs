using AutoMapper;
using Data.Interfaces.Inventory;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Inventory
{
    public class BitacoraInventarioData : BaseModelData<BitacoraInventario, BitacoraInventarioDto>, IBitacoraInventarioData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public BitacoraInventarioData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<BitacoraInventarioDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            bit.Id,
                            bit.Activo,
                            bit.CreateAt,
                            bit.Codigo,
                            bit.Cantidad,
                            bit.Observacion,
                            bit.EmpleadoId,
                            bit.InsumoId,
                            CONCAT(per.PrimerNombre, ' ', per.PrimerApellido) AS Empleado,
                            pro.Nombre AS Insumo
                        FROM
                            BitacorasInventarios AS bit
                            INNER JOIN Empleados emp ON bit.EmpleadoId = emp.Id
                            INNER JOIN Insumos pro ON bit.InsumoId = pro.Id
                            LEFT JOIN Personas per ON emp.PersonaId = per.Id
                        WHERE bit.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND bit." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(bit.Codigo, pro.Nombre, per.PrimerNombre, per.PrimerApellido)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "bit.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<BitacoraInventarioDto> items = await _applicationContext.QueryAsync<BitacoraInventarioDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
