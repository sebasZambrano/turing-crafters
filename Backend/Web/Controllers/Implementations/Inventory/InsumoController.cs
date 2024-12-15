using Business.Interfaces;
using Business.Interfaces.Inventory;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;
using Web.Controllers.Interfaces.Inventory;

namespace Web.Controllers.Implementations.Inventory
{
    public class InsumoController : BaseModelController<Insumo, InsumoDto>, IInsumoController
    {
        private readonly IInsumoBusiness _business;

        public InsumoController(IBaseModelBusiness<Insumo, InsumoDto> baseBusiness, IInsumoBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
