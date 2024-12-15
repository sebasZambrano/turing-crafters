using AutoMapper;
using Business.Interfaces.Parameter;
using Data.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Business.Implementations.Parameter
{
    public class DepartamentoBusiness : BaseModelBusiness<Departamento, DepartamentoDto>, IDepartamentoBusiness
    {
        private readonly IDepartamentoData _data;

        public DepartamentoBusiness(IDepartamentoData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
        }
    }
}
