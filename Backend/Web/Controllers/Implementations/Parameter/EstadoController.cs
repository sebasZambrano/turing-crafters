using Business.Interfaces;
using Business.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class EstadoController : BaseModelController<Estado, EstadoDto>
    {
        private readonly IEstadoBusiness _business;

        public EstadoController(IBaseModelBusiness<Estado, EstadoDto> baseBusiness, IEstadoBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
