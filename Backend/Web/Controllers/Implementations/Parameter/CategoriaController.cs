using Business.Interfaces;
using Business.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class CategoriaController : BaseModelController<Categoria, CategoriaDto>
    {
        private readonly ICategoriaBusiness _business;

        public CategoriaController(IBaseModelBusiness<Categoria, CategoriaDto> baseBusiness, ICategoriaBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
