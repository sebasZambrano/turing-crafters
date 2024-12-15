using Business.Interfaces;
using Business.Interfaces.Operational;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Web.Controllers.Interfaces.Operational;

namespace Web.Controllers.Implementations.Operational
{
    public class PropinaController : BaseModelController<Propina, PropinaDto>, IPropinaController
    {
        private readonly IPropinaBusiness _business;
        public PropinaController(IBaseModelBusiness<Propina, PropinaDto> baseBusiness, IPropinaBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
