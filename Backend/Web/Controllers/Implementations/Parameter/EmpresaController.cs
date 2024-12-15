using Business.Interfaces;
using Business.Interfaces.Operational;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Web.Controllers.Interfaces.Operational;

namespace Web.Controllers.Implementations.Parameter
{
    public class EmpresaController : BaseModelController<Empresa, EmpresaDto>, IEmpresaController
    {
        private readonly IEmpresaBusiness _business;
        public EmpresaController(IBaseModelBusiness<Empresa, EmpresaDto> baseBusiness, IEmpresaBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
