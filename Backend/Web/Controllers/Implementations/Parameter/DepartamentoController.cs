using Business.Interfaces;
using Business.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class DepartamentoController : BaseModelController<Departamento, DepartamentoDto>
    {
        private readonly IDepartamentoBusiness _business;

        public DepartamentoController(IBaseModelBusiness<Departamento, DepartamentoDto> baseBusiness, IDepartamentoBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
