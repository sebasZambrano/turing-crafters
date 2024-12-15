using AutoMapper;
using Business.Interfaces.Operational;
using Data.Interfaces;
using Data.Interfaces.Operational;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Business.Implementations.Operational
{
    public class EmpresaBusiness : BaseModelBusiness<Empresa, EmpresaDto>, IEmpresaBusiness
    {
        private readonly IEmpresaData _data;
        private readonly IMapper _mapper;
        public EmpresaBusiness(IEmpresaData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _mapper = mapper;
        }
    }
}
