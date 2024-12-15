using Business.Interfaces;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;

namespace Web.Controllers.Implementations.Inventory
{
    public class InventarioController : BaseModelController<Inventario, InventarioDto>
    {
        public InventarioController(IBaseModelBusiness<Inventario, InventarioDto> business) : base(business)
        {
        }
    }
}
