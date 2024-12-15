using Business.Interfaces;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class ZonaController : BaseModelController<Zona, ZonaDto>
    {
        public ZonaController(IBaseModelBusiness<Zona, ZonaDto> business) : base(business)
        {
        }
    }
}
