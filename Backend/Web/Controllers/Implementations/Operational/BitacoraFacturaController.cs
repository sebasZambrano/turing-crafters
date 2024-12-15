using Business.Interfaces;
using Business.Interfaces.Operational;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Web.Controllers.Interfaces.Operational;

namespace Web.Controllers.Implementations.Operational
{
    public class BitacoraFacturaController : BaseModelController<BitacoraFactura, BitacoraFacturaDto>, IBitacoraFacturaController
    {
        private readonly IBitacoraFacturaBusiness _business;

        public BitacoraFacturaController(IBaseModelBusiness<BitacoraFactura, BitacoraFacturaDto> baseBusiness, IBitacoraFacturaBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
