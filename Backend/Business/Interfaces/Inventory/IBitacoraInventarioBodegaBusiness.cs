using Entity.Models.Inventory;
using Entity.Dtos.Inventory;

namespace Business.Interfaces.Inventory
{
    public interface IBitacoraInventarioBodegaBusiness : IBaseModelBusiness<BitacoraInventarioBodega, BitacoraInventarioBodegaDto>
    {
        /// <summary>
        /// GenerarCodigo
        /// </summary>
        /// <returns></returns>
        Task<string> GenerarCodigo();
    }
}
