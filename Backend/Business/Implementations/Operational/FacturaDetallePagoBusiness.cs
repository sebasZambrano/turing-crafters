using AutoMapper;
using Business.Interfaces.Operational;
using Data.Interfaces.Operational;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Business.Implementations.Operational
{
    public class FacturaDetallePagoBusiness : BaseModelBusiness<FacturaDetallePago, FacturaDetallePagoDto>, IFacturaDetallePagoBusiness
    {
        private readonly IFacturaDetallePagoData _data;
        private readonly IMapper _mapper;

        public FacturaDetallePagoBusiness(IFacturaDetallePagoData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public async Task<List<FacturaDetallePagoDto>> GetSalesDate(QueryFilterDto filter, string parametro)
        {
            return (List<FacturaDetallePagoDto>)await _data.GetSalesDate(filter, parametro);
        }

        public async Task SaveDetalles(FacturaDetallePagoDto[] facturasDetallesPagosDto)
        {
            var facturasDetallesPagos = _mapper.Map<FacturaDetallePago[]>(facturasDetallesPagosDto);
            await _data.SaveDetalles(facturasDetallesPagos);
        }

        public async Task<List<FacturaDetallePagoDto>> GetSalesCalendar(QueryFilterDto filter, string parametro)
        {
            return (List<FacturaDetallePagoDto>)await _data.GetSalesCalendar(filter, parametro);
        }
    }
}
