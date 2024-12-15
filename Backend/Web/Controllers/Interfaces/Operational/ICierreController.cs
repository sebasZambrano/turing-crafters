using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Entity.Models.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces.Operational
{
    public interface ICierreController : IBaseModelController<Cierre, CierreDto>
    {
        Task<ActionResult<Archivo>> GetArchivoById(int id);
    }
}
