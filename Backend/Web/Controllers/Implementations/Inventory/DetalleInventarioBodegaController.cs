using Business.Interfaces;
using Business.Interfaces.Inventory;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interfaces.Inventory;

namespace Web.Controllers.Implementations.Inventory
{
    public class DetalleInventarioBodegaController : BaseModelController<DetalleInventarioBodega, DetalleInventarioBodegaDto>, IDetalleInventarioBodegaController
    {
        private readonly IDetalleInventarioBodegaBusiness _business;

        public DetalleInventarioBodegaController(IBaseModelBusiness<DetalleInventarioBodega, DetalleInventarioBodegaDto> baseBusiness, IDetalleInventarioBodegaBusiness business) : base(baseBusiness)
        {
            _business = business;
        }

        /// <summary>
        /// SaveDetalles
        /// </summary>
        /// <param name="detalleInventarioBodegaDto"></param>
        /// <returns></returns>
        [HttpPost("saveDetalles")]
        public async Task<ActionResult> SaveDetalles(DetalleInventarioBodegaDto[] detalleInventarioBodegaDto)
        {
            try
            {
                await _business.SaveDetalles(detalleInventarioBodegaDto);

                var response = new ApiResponse<DetalleInventarioBodegaDto[]>(detalleInventarioBodegaDto, true, "Registros almacenados exitosamente", null!);

                return new CreatedAtRouteResult(new { id = detalleInventarioBodegaDto[0].Id }, response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<DetalleInventarioBodegaDto[]>(null!, false, ex.Message.ToString(), null!);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
        /// <summary>
        /// UpdateDetalles
        /// </summary>
        /// <param name="detalleInventarioBodegaDto"></param>
        /// <returns></returns>
        [HttpPost("updateDetalles")]
        public async Task<ActionResult> UpdateDetalles(DetalleInventarioBodegaDto[] detalleInventarioBodegaDto)
        {
            try
            {
                await _business.UpdateDetalles(detalleInventarioBodegaDto);

                var response = new ApiResponse<DetalleInventarioBodegaDto[]>(detalleInventarioBodegaDto, true, "Registros actualizados exitosamente", null!);

                return new CreatedAtRouteResult(new { id = detalleInventarioBodegaDto[0].Id }, response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<DetalleInventarioBodegaDto[]>(null!, false, ex.Message.ToString(), null!);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
        /// <summary>
        /// TrasladoBodegas
        /// </summary>
        /// <param name="lstTrasladoBodegaDto"></param>
        /// <returns></returns>
        [HttpPost("trasladoBodegas")]
        public async Task<ActionResult> TrasladoBodegas(TrasladoBodegaDto[] lstTrasladoBodegaDto)
        {
            try
            {
                await _business.TrasladoBodegas(lstTrasladoBodegaDto);

                var response = new ApiResponse<TrasladoBodegaDto[]>(lstTrasladoBodegaDto, true, "Registros Actualizados exitosamente", null!);

                return new CreatedAtRouteResult(new { id = lstTrasladoBodegaDto[0].InventarioDetalleId }, response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<TrasladoBodegaDto[]>(null!, false, ex.Message.ToString(), null!);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
