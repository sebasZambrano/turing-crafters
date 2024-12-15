using Business.Interfaces;
using Business.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Web.Controllers.Interfaces.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class SalonController : BaseModelController<Salon, SalonDto>, ISalonController
    {
        private readonly ISalonBusiness _business;

        public SalonController(IBaseModelBusiness<Salon, SalonDto> baseBusiness, ISalonBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
