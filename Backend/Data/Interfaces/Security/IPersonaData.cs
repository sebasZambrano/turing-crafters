using Entity.Dtos.Security;
using Entity.Models.Security;

namespace Data.Interfaces.Security
{
    public interface IPersonaData : IBaseModelData<Persona, PersonaDto>
    {
        /// <summary>
        /// Obtener por documento
        /// </summary>
        /// <param name="documento"></param>
        /// <returns></returns>
        Task<Persona> GetByDocument(string documento);
    }
}
