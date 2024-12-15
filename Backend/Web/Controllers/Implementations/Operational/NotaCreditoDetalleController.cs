using Business.Interfaces;
using Business.Interfaces.Operational;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Web.Controllers.Interfaces.Operational;

namespace Web.Controllers.Implementations.Operational
{
    public class NotaCreditoDetalleController : BaseModelController<NotaCreditoDetalle, NotaCreditoDetalleDto>, INotaCreditoDetalleController
    {
        private readonly INotaCreditoDetalleBusiness _business;

        public NotaCreditoDetalleController(IBaseModelBusiness<NotaCreditoDetalle, NotaCreditoDetalleDto> baseBusiness, INotaCreditoDetalleBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
