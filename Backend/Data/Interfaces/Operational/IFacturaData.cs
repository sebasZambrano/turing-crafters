using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Data.Interfaces.Operational
{
    public interface IFacturaData : IBaseModelData<Factura, FacturaDto>
    {
        /// <summary>
        /// GetByDate
        /// </summary>
        /// <param name="FechaInicio"></param>
        /// <param name="FechaFin"></param>
        /// <returns></returns>
        Task<IEnumerable<FacturaDto>> GetByDate(DateTime FechaInicio, DateTime FechaFin);

        /// <summary>
        /// GetByDate
        /// </summary>
        /// <param name="FechaInicio"></param>
        /// <param name="FechaFin"></param>
        /// <param name="EstadoId"></param>
        /// <returns></returns>
        Task<IEnumerable<FacturaDto>> GetByDateAnulada(DateTime FechaInicio, DateTime FechaFin, int EstadoId);
        /// <summary>
        /// GetByDate
        /// </summary>
        /// <param name="FechaInicio"></param>
        /// <param name="FechaFin"></param>
        /// <param name="CajaId"></param>
        /// <returns></returns>
        Task<IEnumerable<FacturaDto>> GetByDateCaja(DateTime FechaInicio, DateTime FechaFin, int CajaId);
    }
}
