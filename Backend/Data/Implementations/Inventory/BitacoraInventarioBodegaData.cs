using AutoMapper;
using Data.Interfaces.Inventory;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Inventory
{
    public class BitacoraInventarioBodegaData : BaseModelData<BitacoraInventarioBodega, BitacoraInventarioBodegaDto>, IBitacoraInventarioBodegaData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public BitacoraInventarioBodegaData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<BitacoraInventarioBodegaDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            bit.Id,
                            bit.Activo,
                            bit.CreateAt,
                            bit.Codigo,
                            bit.Cantidad,
                            bit.Observacion,
                            bit.DetalleInventarioBodegaId,
                            insumo.Id AS InsumoId,
                            insumo.Nombre AS Insumo,
                            bit.EmpleadoId,
                            CONCAT(per.PrimerNombre, ' ', per.PrimerApellido) AS Empleado,
                            bit.FacturaCompraId,
                            facturaCompra.NumeroFactura AS FacturaCompra
                        FROM
                            BitacorasInventariosBodegas AS bit
                            INNER JOIN DetallesInventariosBodegas detalleBodega ON bit.DetalleInventarioBodegaId = detalleBodega.Id
                            INNER JOIN InventariosDetalles detalleInventario ON detalleBodega.InventarioDetalleId = detalleInventario.Id
                            INNER JOIN Insumos insumo ON detalleInventario.InsumoId = insumo.Id
                            LEFT JOIN FacturasCompras facturaCompra ON bit.FacturaCompraId = facturaCompra.Id
                            INNER JOIN Empleados emp ON bit.EmpleadoId = emp.Id
                            LEFT JOIN Personas per ON emp.PersonaId = per.Id
                        WHERE bit.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND bit." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(bit.Codigo, per.PrimerNombre, per.PrimerApellido, facturaCompra.NumeroFactura, insumo.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "bit.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<BitacoraInventarioBodegaDto> items = await _applicationContext.QueryAsync<BitacoraInventarioBodegaDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
