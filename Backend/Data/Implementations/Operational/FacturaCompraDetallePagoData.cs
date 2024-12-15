using AutoMapper;
using Data.Interfaces.Operational;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Operational
{
    public class FacturaCompraDetallePagoData : BaseModelData<FacturaCompraDetallePago, FacturaCompraDetallePagoDto>, IFacturaCompraDetallePagoData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public FacturaCompraDetallePagoData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<FacturaCompraDetallePagoDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            detallePago.Id,
                            detallePago.Activo,
                            detallePago.CreateAt,
                            detallePago.Valor,
                            detallePago.PagoCaja,
                            detallePago.Observacion,
                            detallePago.EmpleadoId,
                            CONCAT(perEmpleado.PrimerNombre, ' ', perEmpleado.PrimerApellido) AS Empleado,
                            detallePago.MedioPagoId,
                            medioPago.Nombre AS MedioPago,
                            detallePago.FacturaCompraId,
                            factura.NumeroFactura AS FacturaCompra
                        FROM
                            FacturasComprasDetallesPagos AS detallePago
                        INNER JOIN MediosPagos medioPago ON detallePago.MedioPagoId = medioPago.Id
                        INNER JOIN FacturasCompras factura ON detallePago.FacturaCompraId = factura.Id
                        INNER JOIN Empleados empleado ON detallePago.EmpleadoId = empleado.Id
                        INNER JOIN Personas perEmpleado ON empleado.PersonaId = perEmpleado.Id
                        WHERE detallePago.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND detallePago." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT()) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "detallePago.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<FacturaCompraDetallePagoDto> items = await _applicationContext.QueryAsync<FacturaCompraDetallePagoDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
