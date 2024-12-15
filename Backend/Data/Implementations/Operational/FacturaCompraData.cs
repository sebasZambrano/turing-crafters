using AutoMapper;
using Data.Interfaces.Operational;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Operational
{
    public class FacturaCompraData : BaseModelData<FacturaCompra, FacturaCompraDto>, IFacturaCompraData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public FacturaCompraData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<FacturaCompraDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            facturaCompra.Id,
                            facturaCompra.Activo,
                            facturaCompra.CreateAt,
                            facturaCompra.NumeroFactura,
                            facturaCompra.Fecha,
                            facturaCompra.Total,
                            facturaCompra.Descuento,
                            facturaCompra.Iva,
                            facturaCompra.PagoCaja,
                            facturaCompra.ProveedorId,
                            empresaProveedor.RazonSocial AS Proveedor,
                            facturaCompra.EstadoId,
                            estado.Nombre AS Estado,
                            facturaCompra.EmpleadoId,
                            CONCAT(perEmpleado.PrimerNombre, ' ', perEmpleado.PrimerApellido) AS Empleado
                        FROM
                            FacturasCompras AS facturaCompra
                        INNER JOIN Proveedores proveedor ON facturaCompra.ProveedorId = proveedor.Id
                        INNER JOIN Empresas empresaProveedor ON proveedor.EmpresaId = empresaProveedor.Id
                        INNER JOIN Estados estado ON facturaCompra.EstadoId = estado.Id
                        INNER JOIN Empleados empleado ON facturaCompra.EmpleadoId = empleado.Id
                        INNER JOIN Personas perEmpleado ON empleado.PersonaId = perEmpleado.Id
                        WHERE facturaCompra.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND facturaCompra." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(facturaCompra.NumeroFactura, empresaProveedor.RazonSocial, estado.Nombre, perEmpleado.PrimerNombre, perEmpleado.PrimerApellido)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "facturaCompra.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<FacturaCompraDto> items = await _applicationContext.QueryAsync<FacturaCompraDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }

        public async Task<IEnumerable<FacturaCompraDto>> GetDebtsDate(QueryFilterDto filter, string parametro, int estadoId)
        {
            var sql = @"SELECT
                            fact.NumeroFactura,
                            fact.Saldo AS Total
                        FROM FacturasCompras AS fact
                        WHERE EstadoId = @estadoId AND ";

            switch (parametro)
            {
                case "DIA":
                    sql += "YEAR(fact.Fecha) = YEAR(@fecha) AND MONTH(fact.Fecha) = MONTH(@fecha) AND DAY(fact.Fecha) = DAY(@fecha) ";
                    break;
                case "MES":
                    sql += "YEAR(fact.Fecha) = YEAR(@fecha) AND MONTH(fact.Fecha) = MONTH(@fecha) ";
                    break;
                case "AÑO":
                    sql += "YEAR(fact.Fecha) = YEAR(@fecha) ";
                    break;
            }

            sql += "AND fact.Saldo > 0 ORDER BY fact.Total desc";

            return await _applicationContext.QueryAsync<FacturaCompraDto>(sql, new { fecha = filter.Filter, estadoId = estadoId });
        }

        public async Task<IEnumerable<FacturaCompraDto>> GetDebtsCalendar(QueryFilterDto filter, string parametro, int estadoId)
        {
            var sql = @"SELECT ";

            if (parametro == "AÑO")
            {
                sql += "MONTH(fact.Fecha) AS Mes, ";
            }
            else
            {
                sql += "DAY(fact.Fecha) AS Dia, ";
            }

            sql += "SUM(fact.Saldo) AS Total FROM FacturasCompras AS fact WHERE EstadoId = @estadoId AND ";

            switch (parametro)
            {
                case "DIA":
                    sql += "YEAR(fact.Fecha) = YEAR(@fecha) AND MONTH(fact.Fecha) = MONTH(@fecha) AND DAY(fact.Fecha) = DAY(@fecha)";
                    break;
                case "MES":
                    sql += "YEAR(fact.Fecha) = YEAR(@fecha) AND MONTH(fact.Fecha) = MONTH(@fecha)";
                    break;
                case "AÑO":
                    sql += "YEAR(fact.Fecha) = YEAR(@fecha)";
                    break;
            }
            sql += " AND fact.Saldo > 0 GROUP BY fact.Fecha";

            return await _applicationContext.QueryAsync<FacturaCompraDto>(sql, new { fecha = filter.Filter, estadoId = estadoId });
        }
    }
}
