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
    public class FacturaController : BaseModelController<Factura, FacturaDto>, IFacturaController
    {
        private readonly IFacturaBusiness _business;

        public FacturaController(IBaseModelBusiness<Factura, FacturaDto> baseBusiness, IFacturaBusiness business) : base(baseBusiness)
        {
            _business = business;
        }

        /// <summary>
        /// GenerarFactura
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("generarFactura/{id}")]
        public async Task<ActionResult<Archivo>> GenerarFactura(int id)
        {
            try
            {
                Archivo archivo = await _business.GenerarFactura(id);
                var response = new ApiResponse<Archivo>(archivo, true, "Factura creada exitosamente", null!);

                return new CreatedAtRouteResult(new { id = archivo.Id }, response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<Archivo>>(null!, false, ex.Message.ToString(), null!);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// getArchivoById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getArchivoById/{id}")]
        public async Task<ActionResult<Archivo>> GetArchivoById(int id)
        {
            try
            {
                var data = await _business.GetArchivoById(id);

                if (data == null)
                {
                    var responseNull = new ApiResponse<Archivo>(null!, false, "Registro no encontrado", null!);
                    return NotFound(responseNull);
                }

                var response = new ApiResponse<Archivo>(data, true, "Ok", null!);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<Archivo>>(null!, false, ex.Message.ToString(), null!);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Anular
        /// </summary>
        /// <param name="id"></param>
        /// <param name="empleadoId"></param>
        /// <returns></returns>
        [HttpPut("anular/{id}/{empleadoId}")]
        public async Task<ActionResult> Anular(int id, int empleadoId)
        {
            try
            {
                await _business.Anular(id, empleadoId);

                var response = new ApiResponse<FacturaDto>(null!, true, "Factura anulada exitosamente", null!);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<FacturaDto>>(null!, false, ex.Message.ToString(), null!);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
