using Business.Interfaces;
using Business.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Web.Controllers.Interfaces.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class EmpleadoController : BaseModelController<Empleado, EmpleadoDto>, IEmpleadoController
    {
        private readonly IEmpleadoBusiness _business;
        public EmpleadoController(IBaseModelBusiness<Empleado, EmpleadoDto> baseBusiness, IEmpleadoBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
