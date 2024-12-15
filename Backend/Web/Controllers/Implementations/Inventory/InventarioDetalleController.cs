using Business.Interfaces;
using Business.Interfaces.Inventory;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;
using Web.Controllers.Interfaces.Inventory;

namespace Web.Controllers.Implementations.Inventory
{
    public class InventarioDetalleController : BaseModelController<InventarioDetalle, InventarioDetalleDto>, IInventarioDetalleController
    {
        private readonly IInventarioDetalleBusiness _business;

        public InventarioDetalleController(IBaseModelBusiness<InventarioDetalle, InventarioDetalleDto> baseBusiness, IInventarioDetalleBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
