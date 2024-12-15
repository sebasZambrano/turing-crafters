using Entity.Dtos.Inventory;
using Entity.Models.Inventory;

namespace Business.Interfaces.Inventory
{
    public interface IDetalleInventarioBodegaBusiness : IBaseModelBusiness<DetalleInventarioBodega, DetalleInventarioBodegaDto>
    {
        /// <summary>
        /// Guardar
        /// </summary>
        /// <param name="detalleInventarioBodegaDto"></param>
        /// <returns></returns>
        Task SaveDetalles(DetalleInventarioBodegaDto[] detalleInventarioBodegaDto);
        /// <summary>
        /// Actualizar
        /// </summary>
        /// <param name="detalleInventarioBodegaDto"></param>
        /// <returns></returns>
        Task UpdateDetalles(DetalleInventarioBodegaDto[] detalleInventarioBodegaDto);
        /// <summary>
        /// TrasladoBodegas
        /// </summary>
        /// <param name="lstTrasladoBodegaDto"></param>
        /// <returns></returns>
        Task TrasladoBodegas(TrasladoBodegaDto[] detalleInventarioBodegaDto);
    }
}
