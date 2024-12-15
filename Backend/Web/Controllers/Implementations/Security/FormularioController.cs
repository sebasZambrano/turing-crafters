using Business.Interfaces;
using Business.Interfaces.Security;
using Entity.Dtos.Security;
using Entity.Models.Security;

namespace Web.Controllers.Implementations.Security
{
    public class FormularioController : BaseModelController<Formulario, FormularioDto>
    {
        private readonly IFormularioBusiness _business;

        public FormularioController(IBaseModelBusiness<Formulario, FormularioDto> baseBusiness, IFormularioBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
