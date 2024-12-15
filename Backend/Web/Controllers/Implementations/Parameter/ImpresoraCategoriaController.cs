using Business.Interfaces;
using Business.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Web.Controllers.Interfaces.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class ImpresoraCategoriaController : BaseModelController<ImpresoraCategoria, ImpresoraCategoriaDto>, IImpresoraCategoriaController
    {
        private readonly IImpresoraCategoriaBusiness _business;
        public ImpresoraCategoriaController(IBaseModelBusiness<ImpresoraCategoria, ImpresoraCategoriaDto> baseBusiness, IImpresoraCategoriaBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
