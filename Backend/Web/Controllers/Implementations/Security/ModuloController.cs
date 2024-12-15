using Business.Interfaces;
using Entity.Dtos.Security;
using Entity.Models.Security;

namespace Web.Controllers.Implementations.Security
{
    public class ModuloController : BaseModelController<Modulo, ModuloDto>
    {
        public ModuloController(IBaseModelBusiness<Modulo, ModuloDto> business) : base(business)
        {

        }
    }
}
