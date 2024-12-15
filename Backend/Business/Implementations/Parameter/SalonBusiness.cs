using AutoMapper;
using Business.Interfaces.Parameter;
using Data.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Business.Implementations.Parameter
{
    public class SalonBusiness : BaseModelBusiness<Salon, SalonDto>, ISalonBusiness
    {
        private readonly ISalonData _data;

        public SalonBusiness(ISalonData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
        }
    }
}
