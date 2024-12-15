using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces.Inventory
{
    public interface IInsumoProductoController : IBaseModelController<InsumoProducto, InsumoProductoDto>
    {
        Task<ActionResult<IEnumerable<DetalleInventarioBodegaDto>>> GetOrdenDetalle([FromQuery] QueryFilterDto filters);
    }
}
