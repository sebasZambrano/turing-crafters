using AutoMapper;
using Business.Interfaces.Operational;
using Data.Interfaces.Operational;
using Data.Interfaces.Parameter;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Dtos.Parameter;
using Entity.Models.Operational;
using Entity.Models.Parameter;

namespace Business.Implementations.Operational
{
    public class OrdenBusiness : BaseModelBusiness<Orden, OrdenDto>, IOrdenBusiness
    {
        private readonly IOrdenData _data;
        private readonly IOrdenDetalleData _dataOrdenDetalle;
        private readonly IEstadoData _dataEstado;
        private readonly IMesaData _dataMesa;
        private readonly IMapper _mapper;

        public OrdenBusiness(IOrdenData data, IEstadoData dataEstado, IOrdenDetalleData dataOrdenDetalle, IMesaData dataMesa, IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _dataOrdenDetalle = dataOrdenDetalle;
            _dataEstado = dataEstado;
            _dataMesa = dataMesa;
            _mapper = mapper;
        }

        public override async Task<OrdenDto> Save(OrdenDto dto)
        {
            dto.CreateAt = DateTime.UtcNow.AddHours(-5);
            dto.Codigo = await GenerarCodigo();
            var codigoEstado = "ENPROCESO";

            if (dto.MesaId == 0)
            {
                IEnumerable<MesaDto> mesas = await _dataMesa.GetAllSelect();
                dto.MesaId = mesas.First().Id;
                codigoEstado = "ORDENFACTURADA";
            }
            else
            {
                //Actualizo el estado de la mesa
                Estado estadoMesa = await _dataEstado.GetByCode("MESAOCUPADA");

                Mesa mesa = await _dataMesa.GetById(dto.MesaId);
                mesa.EstadoId = estadoMesa.Id;
                await _dataMesa.Update(mesa);
            }

            Estado estado = await _dataEstado.GetByCode(codigoEstado);
            dto.EstadoId = estado.Id;

            Orden entity = _mapper.Map<Orden>(dto);
            entity = await _data.Save(entity);
            return _mapper.Map<OrdenDto>(entity);
        }

        public async Task<int> Limpiar(int id)
        {
            Orden orden = await _data.GetById(id);

            IEnumerable<OrdenDetalleDto> detalles = await _dataOrdenDetalle.GetDataTable(new QueryFilterDto() { ForeignKey = orden.Id, NameForeignKey = "OrdenId" });

            foreach (var item in detalles)
            {
                await _dataOrdenDetalle.Delete(item.Id);
            }

            //Actualizo el estado de la mesa
            Estado estadoMesa = await _dataEstado.GetByCode("MESADISPONIBLE");

            Mesa mesa = await _dataMesa.GetById(orden.MesaId);
            mesa.EstadoId = estadoMesa.Id;
            await _dataMesa.Update(mesa);

            return await _data.Delete(orden.Id);
        }

        public async Task<string> GenerarCodigo()
        {
            IEnumerable<OrdenDto> ordenes = await _data.GetDataTable(new QueryFilterDto { Filter = "" });
            int cantidadOrdenes = ordenes.Count() + 1;
            string codigo = $"O-{DateTime.UtcNow.AddHours(-5).Year}-{cantidadOrdenes.ToString().PadLeft(4, '0')}";
            return codigo;
        }
    }
}
