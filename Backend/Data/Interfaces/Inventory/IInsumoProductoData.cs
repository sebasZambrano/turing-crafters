using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;

namespace Data.Interfaces.Inventory
{
    public interface IInsumoProductoData : IBaseModelData<InsumoProducto, InsumoProductoDto>
    {
        /// <summary>
        /// Datatable
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<IEnumerable<DetalleInventarioBodegaDto>> GetOrdenDetalle(QueryFilterDto filters);
    }
}
