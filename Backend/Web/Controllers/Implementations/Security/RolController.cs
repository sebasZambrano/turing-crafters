using Business.Interfaces;
using Entity.Dtos.Security;
using Entity.Models.Security;

namespace Web.Controllers.Implementations.Security
{
    public class RolController : BaseModelController<Rol, RolDto>
    {
        public RolController(IBaseModelBusiness<Rol, RolDto> business) : base(business)
        {

        }
    }
}
