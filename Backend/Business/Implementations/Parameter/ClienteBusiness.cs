using AutoMapper;
using Business.Interfaces.Parameter;
using Data.Interfaces;
using Data.Interfaces.Security;
using Entity.Dtos;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Entity.Models.Security;

namespace Business.Implementations.Parameter
{
    public class ClienteBusiness : BaseModelBusiness<Cliente, ClienteDto>, IClienteBusiness
    {
        private readonly IBaseModelData<Cliente, ClienteDto> _data;
        private readonly IPersonaData _dataPersona;
        private readonly IMapper _mapper;

        public ClienteBusiness(IBaseModelData<Cliente, ClienteDto> data, IPersonaData dataPersona, IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _mapper = mapper;
            _dataPersona = dataPersona;
        }

        public override async Task<ClienteDto> Save(ClienteDto dto)
        {
            IEnumerable<ClienteDto> clientes = await _data.GetDataTable(new QueryFilterDto() { ForeignKey = dto.PersonaId, NameForeignKey = "PersonaId" });
            
            if(clientes.Count() > 0)
            {
                throw new Exception("¡Ya existe un cliente asociado a la misma persona!");
            }

            Persona persona = await _dataPersona.GetById(dto.PersonaId);

            dto.CreateAt = DateTime.UtcNow.AddHours(-5);
            dto.Codigo = persona.Documento;
            Cliente entity = _mapper.Map<Cliente>(dto);
            entity = await _data.Save(entity);
            return _mapper.Map<ClienteDto>(entity);
        }

        public override async Task Update(ClienteDto dto)
        {
            IEnumerable<ClienteDto> clientes = await _data.GetDataTable(new QueryFilterDto() { ForeignKey = dto.PersonaId, NameForeignKey = "PersonaId" });

            if (clientes.Count() > 0)
            {
                throw new Exception("¡Ya existe un cliente asociado a la misma persona!");
            }

            dto.CreateAt = DateTime.UtcNow.AddHours(-5);
            Cliente entity = _mapper.Map<Cliente>(dto);
            entity.UpdateAt = DateTime.UtcNow.AddHours(-5);
            await _data.Update(entity);
        }
    }
}
