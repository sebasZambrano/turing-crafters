using AutoMapper;
using Business.Interfaces.Parameter;
using Data.Interfaces.Parameter;
using Entity.Dtos;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Business.Implementations.Parameter
{
    public class EmpleadoBusiness : BaseModelBusiness<Empleado, EmpleadoDto>, IEmpleadoBusiness
    {
        private readonly IEmpleadoData _data;
        private readonly IMapper _mapper;
        public EmpleadoBusiness(IEmpleadoData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public override async Task<EmpleadoDto> Save(EmpleadoDto dto)
        {
            IEnumerable<EmpleadoDto> empleadoExistente = await _data.GetDataTable(new QueryFilterDto() { ForeignKey = dto.PersonaId, NameForeignKey = "PersonaId" });

            if (empleadoExistente.Count() > 0)
            {
                throw new Exception("¡Ya existe un empleado asociado a la misma persona!");
            }

            IEnumerable<EmpleadoDto> cajaExistente = await _data.GetDataTable(new QueryFilterDto() { ForeignKey = dto.CajaId, NameForeignKey = "CajaId" });

            if (cajaExistente.Count() > 0)
            {
                throw new Exception("¡La caja ya está asociada a un empleado!");
            }

            dto.CreateAt = DateTime.UtcNow.AddHours(-5);
            Empleado entity = _mapper.Map<Empleado>(dto);
            entity = await _data.Save(entity);
            return _mapper.Map<EmpleadoDto>(entity);
        }

        public override async Task Update(EmpleadoDto dto)
        {
            IEnumerable<EmpleadoDto> empleadoExistente = await _data.GetDataTable(new QueryFilterDto() { ForeignKey = dto.PersonaId, NameForeignKey = "PersonaId" });

            if (empleadoExistente.Count() > 0)
            {
                throw new Exception("¡Ya existe un empleado asociado a la misma persona!");
            }

            IEnumerable<EmpleadoDto> cajaExistente = await _data.GetDataTable(new QueryFilterDto() { ForeignKey = dto.CajaId, NameForeignKey = "CajaId" });
            
            if (cajaExistente.Count() > 0)
            {
                throw new Exception("¡La caja ya está asociada a un empleado!");
            }

            dto.CreateAt = DateTime.UtcNow.AddHours(-5);
            Empleado entity = _mapper.Map<Empleado>(dto);
            entity.UpdateAt = DateTime.UtcNow.AddHours(-5);
            await _data.Update(entity);
        }
    }
}
