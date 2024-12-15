using Business.Interfaces;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class CargoController : BaseModelController<Cargo, CargoDto>
    {
        public CargoController(IBaseModelBusiness<Cargo, CargoDto> business) : base(business)
        {
        }
    }
}
