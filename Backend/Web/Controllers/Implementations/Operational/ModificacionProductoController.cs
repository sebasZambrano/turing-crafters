using Business.Interfaces;
using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Web.Controllers.Implementations.Operational
{
    public class ModificacionProductoController : BaseModelController<ModificacionProducto, ModificacionProductoDto>
    {
        public ModificacionProductoController(IBaseModelBusiness<ModificacionProducto, ModificacionProductoDto> business) : base(business)
        {
        }
    }
}
