using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Business.Interfaces.Operational
{
    public interface IFacturaCompraDetalleBusiness : IBaseModelBusiness<FacturaCompraDetalle, FacturaCompraDetalleDto>
    {
        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idEmpleado"></param>
        /// <returns></returns>
        Task<int> Delete(int id, int idEmpleado);
    }
}
