using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Entity.Models.Parameter;

namespace Business.Interfaces.Operational
{
    public interface IFacturaBusiness : IBaseModelBusiness<Factura, FacturaDto>
    {
        /// <summary>
        /// GenerarFactura
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Archivo> GenerarFactura(int id);
        /// <summary>
        /// GetArchivoById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Archivo> GetArchivoById(int id);
        /// <summary>
        /// Anular
        /// </summary>
        /// <param name="id"></param>
        /// <param name="empleadoId"></param>
        /// <returns></returns>
        Task Anular(int id, int empleadoId);
    }
}
