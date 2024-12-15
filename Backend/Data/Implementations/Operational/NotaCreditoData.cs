using AutoMapper;
using Data.Interfaces.Operational;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Operational
{
    public class NotaCreditoData : BaseModelData<NotaCredito, NotaCreditoDto>, INotaCreditoData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public NotaCreditoData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<NotaCreditoDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            nota.Id,
                            nota.Activo,
                            nota.CreateAt,
                            nota.Codigo,
                            nota.Concepto,
                            nota.MetodoCredito,
                            nota.Total,
                            nota.PagoCaja,
                            nota.MotivoId,
                            motivo.Nombre AS Motivo,
                            nota.EstadoId,
                            estado.Nombre AS Estado,
                            nota.FacturaId,
                            factura.NumeroFactura AS Factura, 
                            nota.MedioPagoId,
                            medioPago.Nombre AS MedioPago,
                            nota.EmpleadoId,
                            CONCAT(perEmpleado.PrimerNombre, ' ', perEmpleado.PrimerApellido) AS Empleado
                        FROM
                            NotasCreditos AS nota
                        INNER JOIN Motivos motivo ON nota.MotivoId = motivo.Id
                        INNER JOIN Estados estado ON nota.EstadoId = estado.Id
                        INNER JOIN Facturas factura ON nota.FacturaId = factura.Id
                        INNER JOIN MediosPagos medioPago ON nota.MedioPagoId = medioPago.Id
                        INNER JOIN Empleados empleado ON nota.EmpleadoId = empleado.Id
                        INNER JOIN Personas perEmpleado ON empleado.PersonaId = perEmpleado.Id
                        WHERE nota.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND nota." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(nota.Codigo, nota.MetodoCredito, factura.NumeroFactura, motivo.Nombre, estado.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "nota.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<NotaCreditoDto> items = await _applicationContext.QueryAsync<NotaCreditoDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }

        public async Task<IEnumerable<NotaCreditoDto>> GetByDate(DateTime FechaInicio, DateTime FechaFin, int EstadoId)
        {
            var sql = @"SELECT * FROM NotasCreditos WHERE EstadoId = @EstadoId AND UpdateAt BETWEEN @FechaInicio AND @FechaFin";

            return await _applicationContext.QueryAsync<NotaCreditoDto>(sql, new { FechaInicio = FechaInicio, FechaFin = FechaFin, EstadoId = EstadoId });
        }
    }
}
