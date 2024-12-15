using Business.Interfaces;
using Business.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class CiudadController : BaseModelController<Ciudad, CiudadDto>
    {
        private readonly ICiudadBusiness _business;

        public CiudadController(IBaseModelBusiness<Ciudad, CiudadDto> baseBusiness, ICiudadBusiness business) : base(business)
        {
            _business = business;
        }
    }
}
