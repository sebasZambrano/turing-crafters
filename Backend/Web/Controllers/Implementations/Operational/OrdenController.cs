using Business.Interfaces;
using Business.Interfaces.Operational;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interfaces.Operational;

namespace Web.Controllers.Implementations.Operational
{
    public class OrdenController : BaseModelController<Orden, OrdenDto>, IOrdenController
    {
        private readonly IOrdenBusiness _business;
        public OrdenController(IBaseModelBusiness<Orden, OrdenDto> baseBusiness, IOrdenBusiness business) : base(baseBusiness)
        {
            _business = business;
        }

        /// <summary>
        /// Limpiar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("limpiar/{id}")]
        public async Task<ActionResult> Limpiar(int id)
        {
            try
            {
                int registroAfectados = await _business.Limpiar(id);
                if (registroAfectados == 0)
                {
                    var errorResponse = new ApiResponse<IEnumerable<OrdenDto>>(null!, false, "Registros no eliminados!", null!);
                    return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);

                }
                var successResponse = new ApiResponse<OrdenDto>(null!, true, "Registros eliminados exitosamente", null!);
                return Ok(successResponse);
            }
            catch (Exception)
            {
                var errorResponse = new ApiResponse<IEnumerable<OrdenDto>>(null!, false, "¡El registro se encuentra asociado, no se puede eliminar!", null!);
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
