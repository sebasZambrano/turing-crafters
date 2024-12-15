using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Business.Interfaces.Operational
{
    public interface ICostoBusiness : IBaseModelBusiness<Costo, CostoDto>
    {
        /// <summary>
        /// GetBillsDate
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="parametro"></param>
        /// <returns></returns>
        Task<List<CostoDto>> GetBillsDate(QueryFilterDto filter, string parametro);
        /// <summary>
        /// GetBillsCalendar
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="parametro"></param>
        /// <returns></returns>
        Task<List<CostoDto>> GetBillsCalendar(QueryFilterDto filter, string parametro);
    }
}
