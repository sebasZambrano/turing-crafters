using Business.Interfaces;
using Business.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Web.Controllers.Interfaces.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class MesaController : BaseModelController<Mesa, MesaDto>, IMesaController
    {
        private readonly IMesaBusiness _business;
        public MesaController(IBaseModelBusiness<Mesa, MesaDto> baseBusiness, IMesaBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
