using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Data.Interfaces.Operational
{
    public interface IFacturaDetalleData : IBaseModelData<FacturaDetalle, FacturaDetalleDto>
    {
        /// <summary>
        /// Guardar
        /// </summary>
        /// <param name="facturasDetalles"></param>
        /// <returns></returns>
        Task SaveDetalles(FacturaDetalle[] facturasDetalles);
    }
}
