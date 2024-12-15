using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Business.Interfaces.Operational
{
    public interface IOrdenDetalleBusiness : IBaseModelBusiness<OrdenDetalle, OrdenDetalleDto>
    {
        /// <summary>
        /// Guardar
        /// </summary>
        /// <param name="detalles"></param>
        /// <returns></returns>
        Task SaveDetalles(OrdenDetalleDto[] detalles);
    }
}
