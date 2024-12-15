using Business.Interfaces;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class MacroCategoriaController : BaseModelController<MacroCategoria, MacroCategoriaDto>
    {
        public MacroCategoriaController(IBaseModelBusiness<MacroCategoria, MacroCategoriaDto> business) : base(business)
        {
        }
    }
}
