using AutoMapper;
using Data.Interfaces.Operational;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Operational
{
    public class CostoData : BaseModelData<Costo, CostoDto>, ICostoData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public CostoData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<CostoDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            costo.Id,
                            costo.Activo,
                            costo.CreateAt,
                            costo.Descripcion,
                            costo.FechaCosto,
                            costo.Valor,
                            costo.PagoCaja,
                            costo.NumeroFactura,
                            costo.TipoCostoId,
                            tipoCosto.Nombre AS TipoCosto,
                            costo.ProveedorId,
                            empresaProveedor.RazonSocial AS Proveedor,
                            costo.EmpleadoId,
                            CONCAT(perEmpleado.PrimerNombre, ' ', perEmpleado.PrimerApellido) AS Empleado,
                            costo.CajaId,
                            caja.Nombre AS Caja
                        FROM
                            Costos AS costo
                        INNER JOIN TiposCostos tipoCosto ON costo.TipoCostoId = tipoCosto.Id
                        INNER JOIN Proveedores proveedor ON costo.ProveedorId = proveedor.Id
                        INNER JOIN Empresas empresaProveedor ON proveedor.EmpresaId = empresaProveedor.Id
                        INNER JOIN Empleados empleado ON costo.EmpleadoId = empleado.Id
                        INNER JOIN Personas perEmpleado ON empleado.PersonaId = perEmpleado.Id
                        INNER JOIN Cajas caja ON costo.CajaId = caja.Id
                        WHERE costo.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND costo." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(costo.Descripcion, perEmpleado.PrimerNombre, perEmpleado.PrimerApellido, empresaProveedor.RazonSocial)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "costo.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<CostoDto> items = await _applicationContext.QueryAsync<CostoDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }

        public async Task<IEnumerable<CostoDto>> GetByDate(DateTime FechaInicio, DateTime FechaFin, int PagoCaja)
        {
            var sql = @"SELECT * FROM Costos WHERE PagoCaja = @PagoCaja AND FechaCosto BETWEEN @FechaInicio AND @FechaFin";

            return await _applicationContext.QueryAsync<CostoDto>(sql, new { FechaInicio = FechaInicio, FechaFin = FechaFin, PagoCaja = PagoCaja });
        }

        public async Task<IEnumerable<CostoDto>> GetByDateCaja(DateTime FechaInicio, DateTime FechaFin, int PagoCaja, int CajaId)
        {
            var sql = @"SELECT * FROM Costos WHERE CajaId = @CajaId AND PagoCaja = @PagoCaja AND FechaCosto BETWEEN @FechaInicio AND @FechaFin";

            return await _applicationContext.QueryAsync<CostoDto>(sql, new { FechaInicio = FechaInicio, FechaFin = FechaFin, PagoCaja = PagoCaja, CajaId = CajaId });
        }

        public async Task<IEnumerable<CostoDto>> GetBillsDate(QueryFilterDto filter, string parametro)
        {
            var sql = @"SELECT
                            tipoCost.Nombre AS TipoCosto,
                            SUM(cost.Valor) AS Valor
                        FROM Costos AS cost
						    INNER JOIN TiposCostos AS tipoCost ON cost.TipoCostoId = tipoCost.Id
                        WHERE ";

            switch (parametro)
            {
                case "DIA":
                    sql += "YEAR(cost.FechaCosto) = YEAR(@fecha) AND MONTH(cost.FechaCosto) = MONTH(@fecha) AND DAY(cost.FechaCosto) = DAY(@fecha) ";
                    break;
                case "MES":
                    sql += "YEAR(cost.FechaCosto) = YEAR(@fecha) AND MONTH(cost.FechaCosto) = MONTH(@fecha) ";
                    break;
                case "AÑO":
                    sql += "YEAR(cost.FechaCosto) = YEAR(@fecha) ";
                    break;
            }

            sql += "GROUP BY tipoCost.Nombre ORDER BY Valor desc";

            return await _applicationContext.QueryAsync<CostoDto>(sql, new { fecha = filter.Filter });
        }

        public async Task<IEnumerable<CostoDto>> GetBillsCalendar(QueryFilterDto filter, string parametro)
        {
            var sql = @"SELECT ";

            if (parametro == "AÑO")
            {
                sql += "MONTH(costo.FechaCosto) AS Mes, ";
            }
            else
            {
                sql += "DAY(costo.FechaCosto) AS Dia, ";
            }

            sql += "SUM(costo.Valor) AS Valor FROM Costos AS costo INNER JOIN TiposCostos AS tipoCosto ON tipoCosto.Id = costo.TipoCostoId WHERE ";

            switch (parametro)
            {
                case "DIA":
                    sql += "YEAR(costo.FechaCosto) = YEAR(@fecha) AND MONTH(costo.FechaCosto) = MONTH(@fecha) AND DAY(costo.FechaCosto) = DAY(@fecha)";
                    break;
                case "MES":
                    sql += "YEAR(costo.FechaCosto) = YEAR(@fecha) AND MONTH(costo.FechaCosto) = MONTH(@fecha)";
                    break;
                case "AÑO":
                    sql += "YEAR(costo.FechaCosto) = YEAR(@fecha)";
                    break;
            }
            sql += " GROUP BY costo.FechaCosto";

            return await _applicationContext.QueryAsync<CostoDto>(sql, new { fecha = filter.Filter });
        }
    }
}
