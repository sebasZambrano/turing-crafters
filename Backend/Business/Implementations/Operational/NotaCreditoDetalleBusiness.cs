using AutoMapper;
using Business.Interfaces.Operational;
using Data.Interfaces.Operational;
using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Business.Implementations.Operational
{
    public class NotaCreditoDetalleBusiness : BaseModelBusiness<NotaCreditoDetalle, NotaCreditoDetalleDto>, INotaCreditoDetalleBusiness
    {
        private readonly INotaCreditoDetalleData _data;
        private readonly IMapper _mapper;

        public NotaCreditoDetalleBusiness(INotaCreditoDetalleData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _mapper = mapper;
        }
    }
}
