using Entity.Dtos.Security;
using Entity.Models.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces.Security
{
    public interface IUsuarioController : IBaseModelController<Usuario, UsuarioDto>
    {
        /// <summary>
        /// Metodo para iniciar sesion
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        Task<ActionResult> Authentication(AutenticationDto user);

        /// <summary>
        /// Actualizar contrasena del usuario
        /// </summary>
        /// <param name="dataUser"></param>
        /// <returns></returns>
        Task<ActionResult> UpdatePassword(UsuarioChangePasswordDto dataUser);
    }
}
