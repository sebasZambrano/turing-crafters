using Business.Interfaces;
using Business.Interfaces.Security;
using Entity.Dtos.Security;
using Entity.Models.Security;

namespace Web.Controllers.Implementations.Security
{
    public class FormularioRolController : BaseModelController<FormularioRol, FormularioRolDto>
    {
        private readonly IFormularioRolBusiness _business;

        public FormularioRolController(IBaseModelBusiness<FormularioRol, FormularioRolDto> baseBusiness, IFormularioRolBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
