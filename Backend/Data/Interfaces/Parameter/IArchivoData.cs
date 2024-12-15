using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Data.Interfaces.Parameter
{
    public interface IArchivoData : IBaseModelData<Archivo, ArchivoDto>
    {
        /// <summary>
        /// Obtener Nombre de tabla y id de la tabla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        Task<Archivo> GetByTablaId(int id, string nombre);
    }
}
