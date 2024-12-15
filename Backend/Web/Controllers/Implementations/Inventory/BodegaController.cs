using Business.Interfaces;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;

namespace Web.Controllers.Implementations.Inventory
{
    public class BodegaController : BaseModelController<Bodega, BodegaDto>
    {
        public BodegaController(IBaseModelBusiness<Bodega, BodegaDto> business) : base(business)
        {
        }
    }
}
