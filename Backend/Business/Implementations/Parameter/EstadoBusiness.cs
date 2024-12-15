using AutoMapper;
using Business.Interfaces.Parameter;
using Data.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Business.Implementations.Parameter
{
    public class EstadoBusiness : BaseModelBusiness<Estado, EstadoDto>, IEstadoBusiness
    {
        private readonly IEstadoData _data;

        public EstadoBusiness(IEstadoData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
        }
    }
}
