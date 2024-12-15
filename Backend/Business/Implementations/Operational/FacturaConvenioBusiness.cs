using AutoMapper;
using Business.Interfaces.Operational;
using Data.Interfaces.Operational;
using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Business.Implementations.Operational
{
    public class FacturaConvenioBusiness : BaseModelBusiness<FacturaConvenio, FacturaConvenioDto>, IFacturaConvenioBusiness
    {
        private readonly IFacturaConvenioData _data;

        public FacturaConvenioBusiness(IFacturaConvenioData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
        }
    }
}
