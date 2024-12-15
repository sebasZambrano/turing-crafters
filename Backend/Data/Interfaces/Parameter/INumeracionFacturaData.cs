using Entity.Dtos;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Data.Interfaces.Parameter
{
    public interface INumeracionFacturaData : IBaseModelData<NumeracionFactura, NumeracionFacturaDto>
    {
        /// <summary>
        /// GetByTipoActiva
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        Task<IEnumerable<NumeracionFacturaDto>> GetByTipoActiva(string codigo);
    }
}
