using AutoMapper;
using Business.Interfaces.Parameter;
using Data.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Business.Implementations.Parameter
{
    public class CajaBusiness : BaseModelBusiness<Caja, CajaDto>, ICajaBusiness
    {
        private readonly ICajaData _data;

        public CajaBusiness(ICajaData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
        }
    }
}
