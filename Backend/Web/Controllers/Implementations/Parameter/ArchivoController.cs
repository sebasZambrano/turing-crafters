using Business.Interfaces;
using Business.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Web.Controllers.Interfaces.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class ArchivoController : BaseModelController<Archivo, ArchivoDto>, IArchivoController
    {
        private readonly IArchivoBusiness _business;

        public ArchivoController(IBaseModelBusiness<Archivo, ArchivoDto> baseBusiness, IArchivoBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
