using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Data.Interfaces.Operational
{
    public interface IFacturaCompraData : IBaseModelData<FacturaCompra, FacturaCompraDto>
    {
        /// <summary>
        /// GetDebtsDate
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="parametro"></param>
        /// <param name="estadoId"></param>
        /// <returns></returns>
        Task<IEnumerable<FacturaCompraDto>> GetDebtsDate(QueryFilterDto filter, string parametro, int estadoId);
        /// <summary>
        /// GetDebtsCalendar
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="parametro"></param>
        /// <param name="estadoId"></param>
        /// <returns></returns>
        Task<IEnumerable<FacturaCompraDto>> GetDebtsCalendar(QueryFilterDto filter, string parametro, int estadoId);
    }
}
