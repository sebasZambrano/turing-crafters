using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Entity.Models.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces.Operational
{
    public interface IFacturaController : IBaseModelController<Factura, FacturaDto>
    {
        /// <summary>
        /// GenerarFactura
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionResult<Archivo>> GenerarFactura(int id);
        /// <summary>
        /// GetArchivoById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionResult<Archivo>> GetArchivoById(int id);
    }
}
