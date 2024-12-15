using Business.Interfaces;
using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Web.Controllers.Implementations.Operational
{
    public class FacturaConvenioController : BaseModelController<FacturaConvenio, FacturaConvenioDto>
    {
        public FacturaConvenioController(IBaseModelBusiness<FacturaConvenio, FacturaConvenioDto> business) : base(business)
        {
        }
    }
}
