using Business.Interfaces;
using Business.Interfaces.Security;
using Entity.Dtos;
using Entity.Dtos.Security;
using Entity.Models.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interfaces.Security;

namespace Web.Controllers.Implementations.Security
{
    public class UsuarioController : BaseModelController<Usuario, UsuarioDto>, IUsuarioController
    {

        private readonly IUsuarioBusiness _business;
        public UsuarioController(IBaseModelBusiness<Usuario, UsuarioDto> baseBusiness, IUsuarioBusiness business) : base(baseBusiness)
        {
            _business = business;
        }

        /// <summary>
        /// Metodo autenticación
        /// </summary>
        /// <param name="auten"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<ActionResult> Authentication([FromBody] AutenticationDto auten)
        {
            try
            {
                var data = await _business.Authentication(auten.UserName, auten.Password);
                return Ok(new ApiResponse<object>(data, true, "Sesión iniciada exitosamente", null));
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<object>(null, false, ex.Message.ToString(), null);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Metodo para actualizar clave
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("UpdatePassword/{id}")]
        public async Task<ActionResult> UpdatePassword([FromBody] UsuarioChangePasswordDto dto)
        {
            try
            {
                await _business.UpdatePassword(dto);

                var response = new ApiResponse<Usuario>(null, true, "Contraseña cambiada", null);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<Usuario>>(null, false, ex.Message.ToString(), null);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

    }
}
