using Business.Interfaces;
using Business.Interfaces.Security;
using Entity.Dtos.Security;
using Entity.Models.Security;

namespace Web.Controllers.Implementations.Security
{
    public class PersonaController : BaseModelController<Persona, PersonaDto>
    {
        private readonly IPersonaBusiness _business;

        public PersonaController(IBaseModelBusiness<Persona, PersonaDto> baseBusiness, IPersonaBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
