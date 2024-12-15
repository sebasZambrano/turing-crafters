using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Business.Interfaces.Operational
{
    public interface IFacturaDetalleBusiness : IBaseModelBusiness<FacturaDetalle, FacturaDetalleDto>
    {
        /// <summary>
        /// Guardar
        /// </summary>
        /// <param name="facturasDetallesDto"></param>
        /// <returns></returns>
        Task SaveDetalles(FacturaDetalleDto[] facturasDetallesDto);
    }
}
