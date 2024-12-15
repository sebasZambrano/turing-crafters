using Business.Interfaces;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class MedioPagoController : BaseModelController<MedioPago, MedioPagoDto>
    {
        public MedioPagoController(IBaseModelBusiness<MedioPago, MedioPagoDto> business) : base(business)
        {
        }
    }
}
