using Business.Interfaces;
using Business.Interfaces.Inventory;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interfaces.Inventory;

namespace Web.Controllers.Implementations.Inventory
{
    public class InsumoProductoController : BaseModelController<InsumoProducto, InsumoProductoDto>, IInsumoProductoController
    {
        private readonly IInsumoProductoBusiness _business;

        public InsumoProductoController(IBaseModelBusiness<InsumoProducto, InsumoProductoDto> baseBusiness, IInsumoProductoBusiness business) : base(baseBusiness)
        {
            _business = business;
        }

        /// <summary>
        /// GetOrdenDetalle
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpGet("getOrdenDetalle")]
        public async Task<ActionResult<IEnumerable<DetalleInventarioBodegaDto>>> GetOrdenDetalle([FromQuery] QueryFilterDto filters)
        {
            try
            {
                IEnumerable<DetalleInventarioBodegaDto> lstDto = await _business.GetOrdenDetalle(filters);

                var response = new ApiResponse<IEnumerable<DetalleInventarioBodegaDto>>(lstDto, true, "Ok", null!);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<DetalleInventarioBodegaDto>>(null!, false, ex.Message.ToString(), null!);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
