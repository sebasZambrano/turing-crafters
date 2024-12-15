using Business.Interfaces;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class ImpresoraController : BaseModelController<Impresora, ImpresoraDto>
    {
        public ImpresoraController(IBaseModelBusiness<Impresora, ImpresoraDto> business) : base(business)
        {
        }
    }
}
