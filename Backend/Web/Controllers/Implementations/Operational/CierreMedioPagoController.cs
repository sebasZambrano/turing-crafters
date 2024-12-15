using Business.Interfaces;
using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Web.Controllers.Implementations.Operational
{
    public class CierreMedioPagoController : BaseModelController<CierreMedioPago, CierreMedioPagoDto>
    {
        public CierreMedioPagoController(IBaseModelBusiness<CierreMedioPago, CierreMedioPagoDto> business) : base(business)
        {
        }
    }
}
