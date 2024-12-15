using Business.Interfaces;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class TipoCostoController : BaseModelController<TipoCosto, TipoCostoDto>
    {
        public TipoCostoController(IBaseModelBusiness<TipoCosto, TipoCostoDto> business) : base(business)
        {
        }
    }
}
