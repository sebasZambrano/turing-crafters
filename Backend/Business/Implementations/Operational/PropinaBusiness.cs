using AutoMapper;
using Business.Interfaces.Operational;
using Data.Interfaces.Operational;
using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Business.Implementations.Operational
{
    public class PropinaBusiness : BaseModelBusiness<Propina, PropinaDto>, IPropinaBusiness
    {
        private readonly IPropinaData _data;

        public PropinaBusiness(IPropinaData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
        }
    }
}
