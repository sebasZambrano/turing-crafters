using AutoMapper;
using Business.Interfaces.Parameter;
using Data.Interfaces.Parameter;
using Entity.Dtos;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Business.Implementations.Parameter
{
    public class NumeracionFacturaBusiness : BaseModelBusiness<NumeracionFactura, NumeracionFacturaDto>, INumeracionFacturaBusiness
    {
        private readonly INumeracionFacturaData _data;
        private readonly IMapper _mapper;

        public NumeracionFacturaBusiness(INumeracionFacturaData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public override async Task<NumeracionFacturaDto> Save(NumeracionFacturaDto dto)
        {
            NumeracionFactura numeracion = await _data.GetByCode(dto.Codigo);

            if (numeracion != null && numeracion.Activo)
            {
                dto.Activo = false;
            }

            dto.CreateAt = DateTime.UtcNow.AddHours(-5);
            NumeracionFactura entity = _mapper.Map<NumeracionFactura>(dto);
            entity = await _data.Save(entity);

            return _mapper.Map<NumeracionFacturaDto>(entity);
        }

        public override async Task Update(NumeracionFacturaDto dto)
        {
            IEnumerable<NumeracionFacturaDto> numeraciones = await _data.GetByTipoActiva(dto.Codigo);

            if (dto.Activo && numeraciones.Count() > 0 && numeraciones.First().Activo == false)
            {
                throw new Exception("¡No se puede activar esta numeración porque ya hay una activa del mismo tipo!");
            }

            dto.CreateAt = DateTime.UtcNow.AddHours(-5);
            NumeracionFactura entity = _mapper.Map<NumeracionFactura>(dto);
            entity.UpdateAt = DateTime.UtcNow.AddHours(-5);
            await _data.Update(entity);
        }
    }
}
