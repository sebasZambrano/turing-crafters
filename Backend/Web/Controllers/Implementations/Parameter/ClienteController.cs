using Business.Interfaces;
using Business.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Web.Controllers.Interfaces.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class ClienteController : BaseModelController<Cliente, ClienteDto>, IClienteController
    {
        private readonly IClienteBusiness _business;
        public ClienteController(IBaseModelBusiness<Cliente, ClienteDto> baseBusiness, IClienteBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
