using Business.Interfaces;
using Business.Interfaces.Operational;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interfaces.Operational;

namespace Web.Controllers.Implementations.Operational
{
    public class FacturaDetalleController : BaseModelController<FacturaDetalle, FacturaDetalleDto>, IFacturaDetalleController
    {
        private readonly IFacturaDetalleBusiness _business;

        public FacturaDetalleController(IBaseModelBusiness<FacturaDetalle, FacturaDetalleDto> baseBusiness, IFacturaDetalleBusiness business) : base(baseBusiness)
        {
            _business = business;
        }

        /// <summary>
        /// SaveDetalles
        /// </summary>
        /// <param name="facturasDetallesDto"></param>
        /// <returns></returns>
        [HttpPost("saveDetalles")]
        public async Task<ActionResult> SaveDetalles(FacturaDetalleDto[] facturasDetallesDto)
        {
            try
            {
                await _business.SaveDetalles(facturasDetallesDto);

                var response = new ApiResponse<FacturaDetalleDto[]>(facturasDetallesDto, true, "Registros almacenados exitosamente", null!);

                return new CreatedAtRouteResult(new { id = facturasDetallesDto[0].FacturaId }, response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<FacturaDetalleDto[]>(null!, false, ex.Message.ToString(), null!);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
