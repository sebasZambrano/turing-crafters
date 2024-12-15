using Entity.Dtos.Security;
using Entity.Models.Security;

namespace Business.Interfaces.Security
{
    public interface IUsuarioBusiness : IBaseModelBusiness<Usuario, UsuarioDto> 
    {
        /// <summary>
        /// Metodo para iniciar sesion
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        Task<Object> Authentication(string Username, string Password);

        /// <summary>
        /// Actualizar contrasena del usuario
        /// </summary>
        /// <param name="dataUser"></param>
        /// <returns></returns>
        Task UpdatePassword(UsuarioChangePasswordDto dataUser);
       
    }
}
