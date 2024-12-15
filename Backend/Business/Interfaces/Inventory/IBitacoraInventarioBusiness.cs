using Entity.Dtos.Inventory;
using Entity.Models.Inventory;

namespace Business.Interfaces.Inventory
{
    public interface IBitacoraInventarioBusiness: IBaseModelBusiness<BitacoraInventario, BitacoraInventarioDto>
    {
        /// <summary>
        /// GenerarCodigo
        /// </summary>
        /// <returns></returns>
        Task<string> GenerarCodigo();
    }
}
