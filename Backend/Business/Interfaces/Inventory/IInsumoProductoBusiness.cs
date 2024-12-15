using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;

namespace Business.Interfaces.Inventory
{
    public interface IInsumoProductoBusiness : IBaseModelBusiness<InsumoProducto, InsumoProductoDto>
    {
        /// <summary>
        /// Datatable
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<List<DetalleInventarioBodegaDto>> GetOrdenDetalle(QueryFilterDto filters);
    }
}
