using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Business.Interfaces.Operational
{
    public interface IFacturaCompraBusiness : IBaseModelBusiness<FacturaCompra, FacturaCompraDto>
    {
        /// <summary>
        /// GetDebtsDate
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="parametro"></param>
        /// <returns></returns>
        Task<List<FacturaCompraDto>> GetDebtsDate(QueryFilterDto filter, string parametro);
        /// <summary>
        /// GetDebtsCalendar
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="parametro"></param>
        /// <returns></returns>
        Task<List<FacturaCompraDto>> GetDebtsCalendar(QueryFilterDto filter, string parametro);
    }
}
