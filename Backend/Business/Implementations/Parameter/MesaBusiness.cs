using AutoMapper;
using Business.Interfaces.Parameter;
using Data.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Business.Implementations.Parameter
{
    public class MesaBusiness : BaseModelBusiness<Mesa, MesaDto>, IMesaBusiness
    {
        private readonly IMesaData _data;
        private readonly IMapper _mapper;
        private readonly IEstadoData _dataEstado; 

        public MesaBusiness(IMesaData data, IEstadoData dataEstado, IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _dataEstado = dataEstado;
            _mapper = mapper;
        }

        public override async Task<MesaDto> Save(MesaDto dto)
        {
            Estado estado = await _dataEstado.GetByCode("MESADISPONIBLE");
            dto.CreateAt = DateTime.UtcNow.AddHours(-5);
            dto.EstadoId = estado.Id;

            Mesa entity = _mapper.Map<Mesa>(dto);
            entity = await _data.Save(entity);
            return _mapper.Map<MesaDto>(entity);
        }
    }
}
