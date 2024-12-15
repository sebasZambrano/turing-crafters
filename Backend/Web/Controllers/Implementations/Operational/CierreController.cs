using Business.Interfaces;
using Business.Interfaces.Operational;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Entity.Models.Parameter;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interfaces.Operational;

namespace Web.Controllers.Implementations.Operational
{
    public class CierreController : BaseModelController<Cierre, CierreDto>, ICierreController
    {
        private readonly ICierreBusiness _business;

        public CierreController(IBaseModelBusiness<Cierre, CierreDto> baseBusiness, ICierreBusiness business) : base(baseBusiness)
        {
            _business = business;
        }

        [HttpGet("GetArchivoCierre/{id}")]
        public async Task<ActionResult<Archivo>> GetArchivoById(int id)
        {
            try
            {
                var data = await _business.GetArchivoById(id);

                if (data == null)
                {
                    var responseNull = new ApiResponse<Archivo>(null, false, "Registro no encontrado", null);
                    return NotFound(responseNull);
                }

                var response = new ApiResponse<Archivo>(data, true, "Ok", null);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<Archivo>>(null, false, ex.Message.ToString(), null);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
