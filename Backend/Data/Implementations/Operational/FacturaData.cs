using AutoMapper;
using Data.Interfaces.Operational;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Operational
{
    public class FacturaData : BaseModelData<Factura, FacturaDto>, IFacturaData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public FacturaData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<FacturaDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            fac.Id,
                            fac.Activo,
                            fac.CreateAt,
                            fac.NumeroFactura,                               
                            fac.SubTotal,
                            fac.Total,
                            fac.Descuento,
                            fac.Iva,
                            fac.Observacion,
                            fac.Remision,                                
                            fac.ClienteId,
                            CONCAT(per.PrimerNombre, ' ', per.PrimerApellido) AS Cliente,
                            fac.EstadoId,
                            est.Nombre AS Estado,
                            fac.EmpleadoId,
                            CONCAT(perEmp.PrimerNombre, ' ', perEmp.PrimerApellido) AS Empleado,
                            fac.NumeracionFacturaId,                                
                            CONCAT(numFac.Nombre, ' ', numFac.Prefijo) AS NumeracionFactura,
                            fac.CajaId,
                            caja.Nombre AS Caja,
                            fac.OrdenId,
                            orden.Codigo AS Orden,
                            REPLACE(STRING_AGG(pagosString, CHAR(13) + CHAR(10)), ' - ', CHAR(13) + CHAR(10)) AS Pagos
                        FROM Facturas AS fac
                            INNER JOIN Clientes cli ON fac.ClienteId = cli.Id                            
                            INNER JOIN Personas per ON cli.PersonaId = per.Id
                            INNER JOIN Estados est ON fac.EstadoId = est.Id      
                            INNER JOIN Empleados emp ON fac.EmpleadoId = emp.Id
                            INNER JOIN Personas perEmp ON emp.PersonaId = perEmp.Id
                            INNER JOIN NumeracionesFacturas numFac ON fac.NumeracionFacturaId = numFac.Id
                            INNER JOIN Cajas caja ON fac.CajaId = caja.Id
                            INNER JOIN Ordenes orden ON fac.OrdenId = orden.Id
                            INNER JOIN (
                                SELECT
                                    detallesPago.FacturaId,
                                    STRING_AGG(
                                        CONCAT(
                                            pagos.Nombre, 
                                            ': $ ', 
                                            FORMAT(detallesPago.Valor, '#,0')
                                        ), 
                                        CHAR(13) + CHAR(10)
                                    ) AS pagosString
                                FROM FacturasDetallesPago detallesPago
                                INNER JOIN MediosPagos pagos ON detallesPago.MedioPagoId = pagos.Id
                                GROUP BY detallesPago.FacturaId
                            ) AS pagosStringTable ON fac.Id = pagosStringTable.FacturaId
                            WHERE fac.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND fac." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.FechaInicio) && !string.IsNullOrEmpty(filters.FechaFin))
            {
                sql += @"AND fac.CreateAt BETWEEN @FechaInicio AND @FechaFin ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(orden.Codigo, fac.NumeroFactura, fac.SubTotal, fac.Total, fac.Descuento, fac.Iva, fac.Observacion, fac.Remision,"
                           + " fac.ClienteId, per.PrimerNombre, per.PrimerApellido, est.Nombre, perEmp.PrimerNombre, perEmp.PrimerApellido, numFac.Nombre, "
                           + " numFac.Prefijo)) " +
                           "LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "fac.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            sql += @" GROUP BY fac.Id, fac.Activo, fac.CreateAt, fac.NumeroFactura, fac.SubTotal, fac.Total, fac.Descuento,
                                 fac.Iva, fac.Observacion, fac.Remision, fac.ClienteId, per.PrimerNombre, per.PrimerApellido,
                                 fac.EstadoId, est.Nombre, fac.EmpleadoId, perEmp.PrimerNombre, perEmp.PrimerApellido,
                                 fac.NumeracionFacturaId, numFac.Nombre, numFac.Prefijo, fac.CajaId,caja.Nombre, fac.OrdenId, orden.Codigo ";

            IEnumerable<FacturaDto> items = await _applicationContext.QueryAsync<FacturaDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey, FechaInicio = filters.FechaInicio, FechaFin = filters.FechaFin });

            return items;
        }

        public async Task<IEnumerable<FacturaDto>> GetByDate(DateTime FechaInicio, DateTime FechaFin)
        {
            var sql = @"SELECT * FROM Facturas WHERE CreateAt BETWEEN @FechaInicio AND @FechaFin";

            return await _applicationContext.QueryAsync<FacturaDto>(sql, new { FechaInicio = FechaInicio, FechaFin = FechaFin });
        }

        public async Task<IEnumerable<FacturaDto>> GetByDateAnulada(DateTime FechaInicio, DateTime FechaFin, int EstadoId)
        {
            var sql = @"SELECT * FROM Facturas WHERE EstadoId = @EstadoId AND UpdateAt BETWEEN @FechaInicio AND @FechaFin";

            return await _applicationContext.QueryAsync<FacturaDto>(sql, new { FechaInicio = FechaInicio, FechaFin = FechaFin, EstadoId = EstadoId });
        }

        public async Task<IEnumerable<FacturaDto>> GetByDateCaja(DateTime FechaInicio, DateTime FechaFin, int CajaId)
        {
            var sql = @"SELECT * FROM Facturas WHERE CajaId = @CajaId AND CreateAt BETWEEN @FechaInicio AND @FechaFin";

            return await _applicationContext.QueryAsync<FacturaDto>(sql, new { FechaInicio = FechaInicio, FechaFin = FechaFin, CajaId = CajaId });
        }
    }
}
