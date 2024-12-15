using AutoMapper;
using Business.Interfaces.Parameter;
using Data.Interfaces;
using Data.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Business.Implementations.Parameter
{
    public class CiudadBusiness : BaseModelBusiness<Ciudad, CiudadDto>, ICiudadBusiness
    {
        private readonly ICiudadData _data;

        public CiudadBusiness(ICiudadData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
        }
    }
}
