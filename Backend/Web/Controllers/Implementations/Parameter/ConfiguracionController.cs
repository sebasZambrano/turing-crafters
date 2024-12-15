using Business.Interfaces;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class ConfiguracionController : BaseModelController<Configuracion, ConfiguracionDto>
    {
        public ConfiguracionController(IBaseModelBusiness<Configuracion, ConfiguracionDto> business) : base(business)
        {
        }
    }
}
