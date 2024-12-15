using Business.Interfaces;
using Business.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Web.Controllers.Interfaces.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class CajaController : BaseModelController<Caja, CajaDto>, ICajaController
    {
        private readonly ICajaBusiness _business;

        public CajaController(IBaseModelBusiness<Caja, CajaDto> baseBusiness, ICajaBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
