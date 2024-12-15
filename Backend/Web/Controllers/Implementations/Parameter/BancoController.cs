using Business.Interfaces;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class BancoController : BaseModelController<Banco, BancoDto>
    {
        public BancoController(IBaseModelBusiness<Banco, BancoDto> business) : base(business)
        {
        }
    }
}
