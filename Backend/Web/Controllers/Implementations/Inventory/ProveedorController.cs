using Business.Interfaces;
using Business.Interfaces.Inventory;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;
using Web.Controllers.Interfaces.Inventory;

namespace Web.Controllers.Implementations.Inventory
{
    public class ProveedorController : BaseModelController<Proveedor, ProveedorDto>, IProveedorController
    {

        private readonly IProveedorBusiness _business;

        public ProveedorController(IBaseModelBusiness<Proveedor, ProveedorDto> baseBusiness, IProveedorBusiness business) : base(business)
        {
            _business = business;
        }
    }
}
