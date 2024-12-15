using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Data.Interfaces.Operational
{
    public interface ICostoData : IBaseModelData<Costo, CostoDto>
    {
        /// <summary>
        /// GetByDate
        /// </summary>
        /// <param name="FechaInicio"></param>
        /// <param name="FechaFin"></param>
        /// <param name="PagoCaja"></param>
        /// <returns></returns>
        Task<IEnumerable<CostoDto>> GetByDate(DateTime FechaInicio, DateTime FechaFin, int PagoCaja);
        /// <summary>
        /// GetByDate
        /// </summary>
        /// <param name="FechaInicio"></param>
        /// <param name="FechaFin"></param>
        /// <param name="PagoCaja"></param>
        /// <param name="CajaId"></param>
        /// <returns></returns>
        Task<IEnumerable<CostoDto>> GetByDateCaja(DateTime FechaInicio, DateTime FechaFin, int PagoCaja, int CajaId);
        /// <summary>
        /// GetBillsDate
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="parametro"></param>
        /// <returns></returns>
        Task<IEnumerable<CostoDto>> GetBillsDate(QueryFilterDto filter, string parametro);
        /// <summary>
        /// GetBillsCalendar
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="parametro"></param>
        /// <returns></returns>
        Task<IEnumerable<CostoDto>> GetBillsCalendar(QueryFilterDto filter, string parametro);
    }
}
