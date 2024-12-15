using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Entity.Models.Parameter;

namespace Business.Interfaces.Operational
{
    public interface ICierreBusiness : IBaseModelBusiness<Cierre, CierreDto>
    {
        /// <summary>
        /// Obtener Archivo de cierre por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Archivo> GetArchivoById(int id);
    }
}
