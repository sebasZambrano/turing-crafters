using Business.Interfaces;
using Business.Interfaces.Inventory;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;
using Web.Controllers.Interfaces.Inventory;

namespace Web.Controllers.Implementations.Inventory
{
    public class ProductoController : BaseModelController<Producto, ProductoDto>, IProductoController
    {
        private readonly IProductoBusiness _business;

        public ProductoController(IBaseModelBusiness<Producto, ProductoDto> baseBusiness, IProductoBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
