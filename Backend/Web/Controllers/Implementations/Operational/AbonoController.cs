using Business.Interfaces;
using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Web.Controllers.Implementations.Operational
{
    public class AbonoController : BaseModelController<Abono, AbonoDto>
    {
        public AbonoController(IBaseModelBusiness<Abono, AbonoDto> business) : base(business)
        {
        }
    }
}
