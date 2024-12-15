using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Data.Interfaces.Operational
{
    public interface INotaCreditoData : IBaseModelData<NotaCredito, NotaCreditoDto>
    {
        /// <summary>
        /// GetByDate
        /// </summary>
        /// <param name="FechaInicio"></param>
        /// <param name="FechaFin"></param>
        /// <param name="EstadoId"></param>
        /// <returns></returns>
        Task<IEnumerable<NotaCreditoDto>> GetByDate(DateTime FechaInicio, DateTime FechaFin, int EstadoId);
    }
}
