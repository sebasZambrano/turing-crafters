using AutoMapper;
using Business.Interfaces.Operational;
using Data.Interfaces.Operational;
using Data.Interfaces.Parameter;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;
using Entity.Models.Parameter;

namespace Business.Implementations.Operational
{
    public class OrdenDetalleBusiness : BaseModelBusiness<OrdenDetalle, OrdenDetalleDto>, IOrdenDetalleBusiness
    {
        private readonly IOrdenDetalleData _data;
        private readonly IEstadoData _dataEstado;
        private readonly IMapper _mapper;

        public OrdenDetalleBusiness(IOrdenDetalleData data, IEstadoData dataEstado, IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _dataEstado = dataEstado;
            _mapper = mapper;
        }

        public async Task SaveDetalles(OrdenDetalleDto[] detalles)
        {
            Estado estado = await _dataEstado.GetByCode("PREPARACION");

            for (int i = 0; i < detalles.Length; i++)
            {
                detalles[i].CreateAt = DateTime.UtcNow.AddHours(-5);
                detalles[i].EstadoId = estado.Id;
                detalles[i].Codigo = await GenerarCodigo();
            }

            var ordenDetalles = _mapper.Map<OrdenDetalle[]>(detalles);

            await _data.SaveDetalles(ordenDetalles);
        }

        public async Task<string> GenerarCodigo()
        {
            IEnumerable<OrdenDetalleDto> ordenes = await _data.GetDataTable(new QueryFilterDto { Filter = "" });
            int cantidadOrdenes = ordenes.Count() + 1;
            string codigo = $"OD-{DateTime.UtcNow.AddHours(-5).Year}-{cantidadOrdenes.ToString().PadLeft(4, '0')}";
            return codigo;
        }
    }
}
