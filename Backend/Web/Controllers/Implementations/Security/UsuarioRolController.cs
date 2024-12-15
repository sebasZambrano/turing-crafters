using Business.Interfaces;
using Business.Interfaces.Operational;
using Business.Interfaces.Security;
using Entity.Dtos.Security;
using Entity.Models.Security;
using Web.Controllers.Interfaces.Security;

namespace Web.Controllers.Implementations.Security
{
    public class UsuarioRolController : BaseModelController<UsuarioRol, UsuarioRolDto>, IUsuarioRolController
    {
        private readonly IUsuarioRolBusiness _business;
        public UsuarioRolController(IBaseModelBusiness<UsuarioRol, UsuarioRolDto> baseBusiness, IUsuarioRolBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
