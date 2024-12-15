using Business.Interfaces;
using Business.Interfaces.Operational;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Web.Controllers.Interfaces.Operational;

namespace Web.Controllers.Implementations.Operational
{
    public class NotaCreditoController : BaseModelController<NotaCredito, NotaCreditoDto>, INotaCreditoController
    {
        private readonly INotaCreditoBusiness _business;

        public NotaCreditoController(IBaseModelBusiness<NotaCredito, NotaCreditoDto> baseBusiness, INotaCreditoBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
