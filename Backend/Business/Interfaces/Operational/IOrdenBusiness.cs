using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Business.Interfaces.Operational
{
    public interface IOrdenBusiness : IBaseModelBusiness<Orden, OrdenDto>
    {
        /// <summary>
        /// Limpiar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> Limpiar(int id);
    }
}
