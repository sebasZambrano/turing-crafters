using Business.Interfaces;
using Business.Interfaces.Operational;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interfaces.Operational;

namespace Web.Controllers.Implementations.Operational
{
    public class FacturaDetallePagoController : BaseModelController<FacturaDetallePago, FacturaDetallePagoDto>, IFacturaDetallePagoController
    {
        private readonly IFacturaDetallePagoBusiness _business;

        public FacturaDetallePagoController(IBaseModelBusiness<FacturaDetallePago, FacturaDetallePagoDto> baseBusiness, IFacturaDetallePagoBusiness business) : base(baseBusiness)
        {
            _business = business;
        }

        /// <summary>
        /// GetSalesDate
        /// </summary>
        /// <returns></returns>
        [HttpGet("getSalesDate/{parameter}")]
        public async Task<ActionResult<IEnumerable<FacturaDetallePagoDto>>> GetSalesDate([FromQuery] QueryFilterDto filters, string parameter)
        {
            try
            {
                var data = await _business.GetSalesDate(filters, parameter);

                if (data == null)
                {
                    var responseNull = new ApiResponse<IEnumerable<FacturaDetallePagoDto>>(null!, false, "Registro no encontrado", null!);
                    return NotFound(responseNull);
                }

                var response = new ApiResponse<IEnumerable<FacturaDetallePagoDto>>(data, true, "Ok", null!);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<FacturaDetallePagoDto>>(null!, false, ex.Message.ToString(), null!);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
        /// <summary>
        /// GetSalesCalendar
        /// </summary>
        /// <returns></returns>
        [HttpGet("getSalesCalendar/{parameter}")]
        public async Task<ActionResult<IEnumerable<FacturaDetallePagoDto>>> GetSalesCalendar([FromQuery] QueryFilterDto filters, string parameter)
        {
            try
            {
                var data = await _business.GetSalesCalendar(filters, parameter);

                if (data == null)
                {
                    var responseNull = new ApiResponse<IEnumerable<FacturaDetallePagoDto>>(null!, false, "Registro no encontrado", null!);
                    return NotFound(responseNull);
                }

                var response = new ApiResponse<IEnumerable<FacturaDetallePagoDto>>(data, true, "Ok", null!);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<FacturaDetallePagoDto>>(null!, false, ex.Message.ToString(), null!);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
        /// <summary>
        /// SaveDetalles
        /// </summary>
        /// <param name="facturasDetallesPagosDto"></param>
        /// <returns></returns>
        [HttpPost("saveDetalles")]
        public async Task<ActionResult> SaveDetalles(FacturaDetallePagoDto[] facturasDetallesPagosDto)
        {
            try
            {
                await _business.SaveDetalles(facturasDetallesPagosDto);

                var response = new ApiResponse<FacturaDetallePagoDto[]>(facturasDetallesPagosDto, true, "Registros almacenados exitosamente", null!);

                return new CreatedAtRouteResult(new { id = facturasDetallesPagosDto[0].FacturaId }, response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<FacturaDetalleDto[]>(null!, false, ex.Message.ToString(), null!);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
