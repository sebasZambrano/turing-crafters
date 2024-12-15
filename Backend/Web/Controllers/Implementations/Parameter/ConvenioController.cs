using Business.Interfaces;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class ConvenioController : BaseModelController<Convenio, ConvenioDto>
    {
        public ConvenioController(IBaseModelBusiness<Convenio, ConvenioDto> business) : base(business)
        {
        }
    }
}
