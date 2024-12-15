using Business.Interfaces;
using Business.Interfaces.Operational;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interfaces.Operational;

namespace Web.Controllers.Implementations.Operational
{
    public class CostoController : BaseModelController<Costo, CostoDto>, ICostoController
    {
        private readonly ICostoBusiness _business;

        public CostoController(IBaseModelBusiness<Costo, CostoDto> baseBusiness, ICostoBusiness business) : base(baseBusiness)
        {
            _business = business;
        }

        /// <summary>
        /// GetBillsDate
        /// </summary>
        /// <returns></returns>
        [HttpGet("getBillsDate/{parameter}")]
        public async Task<ActionResult<IEnumerable<CostoDto>>> GetBillsDate([FromQuery] QueryFilterDto filters, string parameter)
        {
            try
            {
                var data = await _business.GetBillsDate(filters, parameter);

                if (data == null)
                {
                    var responseNull = new ApiResponse<IEnumerable<CostoDto>>(null!, false, "Registro no encontrado", null!);
                    return NotFound(responseNull);
                }

                var response = new ApiResponse<IEnumerable<CostoDto>>(data, true, "Ok", null!);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<CostoDto>>(null!, false, ex.Message.ToString(), null!);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
        /// <summary>
        /// GetBillsCalendar
        /// </summary>
        /// <returns></returns>
        [HttpGet("getBillsCalendar/{parameter}")]
        public async Task<ActionResult<IEnumerable<CostoDto>>> GetBillsCalendar([FromQuery] QueryFilterDto filters, string parameter)
        {
            try
            {
                var data = await _business.GetBillsCalendar(filters, parameter);

                if (data == null)
                {
                    var responseNull = new ApiResponse<IEnumerable<CostoDto>>(null!, false, "Registro no encontrado", null!);
                    return NotFound(responseNull);
                }

                var response = new ApiResponse<IEnumerable<CostoDto>>(data, true, "Ok", null!);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<CostoDto>>(null!, false, ex.Message.ToString(), null!);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
