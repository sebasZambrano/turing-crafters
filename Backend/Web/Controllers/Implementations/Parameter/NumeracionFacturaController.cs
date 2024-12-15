using Business.Interfaces;
using Business.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Web.Controllers.Interfaces.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class NumeracionFacturaController : BaseModelController<NumeracionFactura, NumeracionFacturaDto>, INumeracionFacturaController
    {
        private readonly INumeracionFacturaBusiness _business;

        public NumeracionFacturaController(IBaseModelBusiness<NumeracionFactura, NumeracionFacturaDto> baseBusiness, INumeracionFacturaBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
