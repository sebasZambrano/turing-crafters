using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Data.Interfaces.Operational
{
    public interface IOrdenDetalleData : IBaseModelData<OrdenDetalle, OrdenDetalleDto>
    {
        /// <summary>
        /// Guardar
        /// </summary
        /// <param name="detalles"></param>
        /// <returns></returns>
        Task SaveDetalles(OrdenDetalle[] detalles);
    }
}
