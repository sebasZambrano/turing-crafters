using Business.Interfaces;
using Business.Interfaces.Operational;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interfaces.Operational;

namespace Web.Controllers.Implementations.Operational
{
    public class OrdenDetalleController : BaseModelController<OrdenDetalle, OrdenDetalleDto>, IOrdenDetalleController
    {
        private readonly IOrdenDetalleBusiness _business;
        public OrdenDetalleController(IBaseModelBusiness<OrdenDetalle, OrdenDetalleDto> baseBusiness, IOrdenDetalleBusiness business) : base(baseBusiness)
        {
            _business = business;
        }

        /// <summary>
        /// SaveDetalles
        /// </summary>
        /// <param name="detalles"></param>
        /// <returns></returns>
        [HttpPost("saveDetalles")]
        public async Task<ActionResult> SaveDetalles(OrdenDetalleDto[] detalles)
        {
            try
            {
                await _business.SaveDetalles(detalles);

                var response = new ApiResponse<OrdenDetalleDto[]>(detalles, true, "Registros almacenados exitosamente", null!);

                return new CreatedAtRouteResult(new { id = detalles[0].OrdenId }, response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<OrdenDetalleDto[]>(null!, false, ex.Message.ToString(), null!);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
