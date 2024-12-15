using Business.Interfaces;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class PaisController : BaseModelController<Pais,PaisDto>
    {
        public PaisController(IBaseModelBusiness<Pais, PaisDto> business) : base(business)
        {
        }
    }
}
