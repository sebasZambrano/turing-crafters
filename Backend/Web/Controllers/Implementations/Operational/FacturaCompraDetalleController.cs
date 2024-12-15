using Business.Interfaces;
using Business.Interfaces.Operational;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interfaces.Operational;

namespace Web.Controllers.Implementations.Operational
{
    public class FacturaCompraDetalleController : BaseModelController<FacturaCompraDetalle, FacturaCompraDetalleDto>, IFacturaCompraDetalleController
    {
        private readonly IFacturaCompraDetalleBusiness _business;

        public FacturaCompraDetalleController(IBaseModelBusiness<FacturaCompraDetalle, FacturaCompraDetalleDto> baseBusiness, IFacturaCompraDetalleBusiness business) : base(baseBusiness)
        {
            _business = business;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idEmpleado"></param>
        /// <returns></returns>
        [HttpDelete("{id}/{idEmpleado}")]
        public async Task<ActionResult> Delete(int id, int idEmpleado)
        {
            try
            {
                int registroAfectados = await _business.Delete(id, idEmpleado);
                if (registroAfectados == 0)
                {
                    var errorResponse = new ApiResponse<IEnumerable<FacturaCompraDetalleDto>>(null!, false, "Registro no eliminado!", null!);
                    return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);

                }
                var successResponse = new ApiResponse<FacturaCompraDetalleDto>(null!, true, "Registro eliminado exitosamente", null!);
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<IEnumerable<FacturaCompraDetalleDto>>(null!, false, "¡El registro se encuentra asociado, no se puede eliminar!", null!);
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
