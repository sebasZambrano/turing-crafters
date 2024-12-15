using Business.Interfaces;
using Business.Interfaces.Operational;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interfaces.Operational;

namespace Web.Controllers.Implementations.Operational
{
    public class FacturaCompraController : BaseModelController<FacturaCompra, FacturaCompraDto>, IFacturaCompraController
    {
        private readonly IFacturaCompraBusiness _business;

        public FacturaCompraController(IBaseModelBusiness<FacturaCompra, FacturaCompraDto> baseBusiness, IFacturaCompraBusiness business) : base(baseBusiness)
        {
            _business = business;
        }

        /// <summary>
        /// GetDebtsDate
        /// </summary>
        /// <returns></returns>
        [HttpGet("getDebtsDate/{parameter}")]
        public async Task<ActionResult<IEnumerable<FacturaCompraDto>>> GetDebtsDate([FromQuery] QueryFilterDto filters, string parameter)
        {
            try
            {
                var data = await _business.GetDebtsDate(filters, parameter);

                if (data == null)
                {
                    var responseNull = new ApiResponse<IEnumerable<FacturaCompraDto>>(null!, false, "Registro no encontrado", null!);
                    return NotFound(responseNull);
                }

                var response = new ApiResponse<IEnumerable<FacturaCompraDto>>(data, true, "Ok", null!);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<FacturaCompraDto>>(null!, false, ex.Message.ToString(), null!);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
        /// <summary>
        /// GetDebtsCalendar
        /// </summary>
        /// <returns></returns>
        [HttpGet("getDebtsCalendar/{parameter}")]
        public async Task<ActionResult<IEnumerable<FacturaCompraDto>>> GetDebtsCalendar([FromQuery] QueryFilterDto filters, string parameter)
        {
            try
            {
                var data = await _business.GetDebtsCalendar(filters, parameter);

                if (data == null)
                {
                    var responseNull = new ApiResponse<IEnumerable<FacturaCompraDto>>(null!, false, "Registro no encontrado", null!);
                    return NotFound(responseNull);
                }

                var response = new ApiResponse<IEnumerable<FacturaCompraDto>>(data, true, "Ok", null!);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<FacturaCompraDto>>(null!, false, ex.Message.ToString(), null!);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
