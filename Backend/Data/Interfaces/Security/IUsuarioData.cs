using Entity.Dtos.Security;
using Entity.Models.Security;

namespace Data.Interfaces.Security
{
    public interface IUsuarioData : IBaseModelData<Usuario, UsuarioDto>
    {
        /// <summary>
        /// Obtener por code
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        Task<UsuarioDto> GetByUserName(string userName);

        /// <summary>
        /// COnsultar menu
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MenuDto>> GetDataMenu();

        /// <summary>
        /// Formulario Menu
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="moduloId"></param>
        /// <returns></returns>
        Task<IEnumerable<FormularioDto>> GetFormularioMenu(int usuarioId, int? moduloId);
    }
}
