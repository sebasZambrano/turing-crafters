using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Business.Interfaces.Operational
{
    public interface IBitacoraFacturaBusiness : IBaseModelBusiness<BitacoraFactura, BitacoraFacturaDto>
    {
        /// <summary>
        /// GenerarCodigo
        /// </summary>
        /// <returns></returns>
        Task<string> GenerarCodigo();
    }
}
