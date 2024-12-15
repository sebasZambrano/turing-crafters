using AutoMapper;
using Data.Interfaces.Operational;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Operational
{
    public class FacturaDetallePagoData : BaseModelData<FacturaDetallePago, FacturaDetallePagoDto>, IFacturaDetallePagoData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public FacturaDetallePagoData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<FacturaDetallePagoDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            detalle.Id,
                            detalle.Activo,
                            detalle.CreateAt,
                            detalle.Valor,
                            detalle.Observacion,
                            detalle.EmpleadoId,
                            CONCAT(per.PrimerNombre, ' ', per.PrimerApellido) AS Empleado,
                            detalle.MedioPagoId,
                            med.Nombre AS MedioPago,
                            detalle.FacturaId,
                            factura.NumeroFactura AS Factura
                        FROM
                            FacturasDetallesPago AS detalle
                        INNER JOIN Empleados emp ON detalle.EmpleadoId = emp.Id
                        INNER JOIN Personas per ON emp.PersonaId = per.Id
                        INNER JOIN MediosPagos med ON detalle.MedioPagoId = med.Id
                        INNER JOIN Facturas factura ON detalle.FacturaId = factura.Id
                        WHERE detalle.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND detalle." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(factura.NumeroFactura, med.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "detalle.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<FacturaDetallePagoDto> items = await _applicationContext.QueryAsync<FacturaDetallePagoDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }

        public async Task<IEnumerable<FacturaDetallePagoDto>> GetSalesDate(QueryFilterDto filter, string parametro)
        {
            var sql = @"SELECT
                            MP.Nombre AS MedioPago,
                            SUM(FDP.Valor) AS Valor
                        FROM FacturasDetallesPago AS FDP 
                        INNER JOIN Facturas AS F ON F.Id = FDP.FacturaId
                        INNER JOIN MediosPagos AS MP ON MP.Id = FDP.MedioPagoId
                        WHERE ";

            switch (parametro)
            {
                case "DIA":
                    sql += "YEAR(FDP.CreateAt) = YEAR(@fecha) AND MONTH(FDP.CreateAt) = MONTH(@fecha) AND DAY(FDP.CreateAt) = DAY(@fecha) ";
                    break;
                case "MES":
                    sql += "YEAR(FDP.CreateAt) = YEAR(@fecha) AND MONTH(FDP.CreateAt) = MONTH(@fecha) ";
                    break;
                case "AÑO":
                    sql += "YEAR(FDP.CreateAt) = YEAR(@fecha) ";
                    break;
            }

            sql += "GROUP BY MP.Nombre ORDER BY Valor desc";

            return await _applicationContext.QueryAsync<FacturaDetallePagoDto>(sql, new { fecha = filter.Filter });
        }

        public async Task<IEnumerable<FacturaDetallePagoDto>> GetSalesCalendar(QueryFilterDto filter, string parametro)
        {
            var sql = @"SELECT ";

            if (parametro == "AÑO")
            {
                sql += "MONTH(FDP.CreateAt) AS Mes, ";
            }
            else
            {
                sql += "DAY(FDP.CreateAt) AS Dia, ";
            }

            sql += "SUM(FDP.Valor) AS Valor FROM FacturasDetallesPago AS FDP INNER JOIN Facturas AS F ON F.Id = FDP.FacturaId WHERE ";

            switch (parametro)
            {
                case "DIA":
                    sql += "YEAR(FDP.CreateAt) = YEAR(@fecha) AND MONTH(FDP.CreateAt) = MONTH(@fecha) AND DAY(FDP.CreateAt) = DAY(@fecha)";
                    break;
                case "MES":
                    sql += "YEAR(FDP.CreateAt) = YEAR(@fecha) AND MONTH(FDP.CreateAt) = MONTH(@fecha)";
                    break;
                case "AÑO":
                    sql += "YEAR(FDP.CreateAt) = YEAR(@fecha)";
                    break;
            }
            sql += " GROUP BY FDP.CreateAt";

            return await _applicationContext.QueryAsync<FacturaDetallePagoDto>(sql, new { fecha = filter.Filter });
        }

        public async Task SaveDetalles(FacturaDetallePago[] facturasDetallesPagos)
        {
            _applicationContext.AddRange(facturasDetallesPagos);
            await _applicationContext.SaveChangesAsync();
        }
    }
}
