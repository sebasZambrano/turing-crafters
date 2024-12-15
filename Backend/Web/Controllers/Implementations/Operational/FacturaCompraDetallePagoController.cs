using Business.Interfaces;
using Business.Interfaces.Operational;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Web.Controllers.Interfaces.Operational;

namespace Web.Controllers.Implementations.Operational
{
    public class FacturaCompraDetallePagoController : BaseModelController<FacturaCompraDetallePago, FacturaCompraDetallePagoDto>, IFacturaCompraDetallePagoController
    {
        private readonly IFacturaCompraDetallePagoBusiness _business;

        public FacturaCompraDetallePagoController(IBaseModelBusiness<FacturaCompraDetallePago, FacturaCompraDetallePagoDto> baseBusiness, IFacturaCompraDetallePagoBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
