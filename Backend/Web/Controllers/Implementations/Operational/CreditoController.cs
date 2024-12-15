using Business.Interfaces;
using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Web.Controllers.Implementations.Operational
{
    public class CreditoController : BaseModelController<Credito, CreditoDto>
    {
        public CreditoController(IBaseModelBusiness<Credito, CreditoDto> business) : base(business)
        {
        }
    }
}
