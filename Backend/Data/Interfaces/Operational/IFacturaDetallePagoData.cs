using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Data.Interfaces.Operational
{
    public interface IFacturaDetallePagoData : IBaseModelData<FacturaDetallePago, FacturaDetallePagoDto>
    {
        /// <summary>
        /// Guardar
        /// </summary>
        /// <param name="facturasDetallesPagos"></param>
        /// <returns></returns>
        Task SaveDetalles(FacturaDetallePago[] facturasDetallesPagos);
        /// <summary>
        /// GetAllDate
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="parametro"></param>
        /// <returns></returns>
        Task<IEnumerable<FacturaDetallePagoDto>> GetSalesDate(QueryFilterDto filter, string parametro);
        /// <summary>
        /// GetSalesCalendar
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="parametro"></param>
        /// <returns></returns>
        Task<IEnumerable<FacturaDetallePagoDto>> GetSalesCalendar(QueryFilterDto filter, string parametro);
    }
}
