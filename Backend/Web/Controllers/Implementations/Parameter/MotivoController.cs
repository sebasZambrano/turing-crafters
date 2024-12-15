using Business.Interfaces;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class MotivoController : BaseModelController<Motivo, MotivoDto>
    {
        public MotivoController(IBaseModelBusiness<Motivo, MotivoDto> business) : base(business)
        {
        }
    }
}
