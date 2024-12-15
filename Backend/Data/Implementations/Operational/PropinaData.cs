using AutoMapper;
using Data.Interfaces.Operational;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Operational
{
    public class PropinaData : BaseModelData<Propina, PropinaDto>, IPropinaData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public PropinaData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<PropinaDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            propina.Id,
                            propina.Activo,
                            propina.CreateAt,
                            propina.Valor,
                            propina.Procentaje,
                            propina.Liquidado,
                            propina.UpdateAt,
                            propina.EmpleadoId,
                            CONCAT(perEmpleado.PrimerNombre, ' ', perEmpleado.PrimerApellido) AS Empleado,
                            propina.FacturaId,  
                            factura.NumeroFactura AS Factura,
                            propina.MedioPagoId,
                            medioPago.Nombre AS MedioPago
                        FROM
                            Propinas AS propina
                        INNER JOIN Empleados empleado ON propina.EmpleadoId = empleado.Id
                        INNER JOIN Personas perEmpleado ON empleado.PersonaId = perEmpleado.Id
                        INNER JOIN Facturas factura ON propina.FacturaId = factura.Id
                        INNER JOIN MediosPagos medioPago ON propina.MedioPagoId = medioPago.Id
                        WHERE propina.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND propina." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(perEmpleado.PrimerNombre, perEmpleado.PrimerApellido)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "propina.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<PropinaDto> items = await _applicationContext.QueryAsync<PropinaDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
