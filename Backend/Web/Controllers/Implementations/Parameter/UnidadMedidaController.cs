using Business.Interfaces;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class UnidadMedidaController : BaseModelController<UnidadMedida, UnidadMedidaDto>
    {
        public UnidadMedidaController(IBaseModelBusiness<UnidadMedida, UnidadMedidaDto> business) : base(business)
        {
        }
    }
}
