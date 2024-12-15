using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Business.Interfaces.Operational
{
    public interface IFacturaDetallePagoBusiness : IBaseModelBusiness<FacturaDetallePago, FacturaDetallePagoDto>
    {
        /// <summary>
        /// Guardar
        /// </summary>
        /// <param name="facturasDetallesPagosDto"></param>
        /// <returns></returns>
        Task SaveDetalles(FacturaDetallePagoDto[] facturasDetallesPagosDto);
        /// <summary>
        /// GetAllDate
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="parametro"></param>
        /// <returns></returns>
        Task<List<FacturaDetallePagoDto>> GetSalesDate(QueryFilterDto filter, string parametro);
        /// <summary>
        /// GetSalesCalendar
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="parametro"></param>
        /// <returns></returns>
        Task<List<FacturaDetallePagoDto>> GetSalesCalendar(QueryFilterDto filter, string parametro);
    }
}
