using Business.Interfaces;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class TipoEstadoController : BaseModelController<TipoEstado, TipoEstadoDto>
    {
        public TipoEstadoController(IBaseModelBusiness<TipoEstado, TipoEstadoDto> business) : base(business)
        {
        }
    }
}
