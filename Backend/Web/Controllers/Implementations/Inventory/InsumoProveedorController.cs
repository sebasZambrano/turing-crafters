using Business.Interfaces;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;

namespace Web.Controllers.Implementations.Inventory
{
    public class InsumoProveedorController : BaseModelController<InsumoProveedor, InsumoProveedorDto>
    {
        public InsumoProveedorController(IBaseModelBusiness<InsumoProveedor, InsumoProveedorDto> business) : base(business)
        {
        }
    }
}
