using AutoMapper;
using Business.Interfaces;
using Business.Interfaces.Security;
using Data.Interfaces;
using Data.Interfaces.Security;
using Entity.Dtos.Security;
using Entity.Models.Security;

namespace Business.Implementations.Security
{
    public class PersonaBusiness : BaseModelBusiness<Persona, PersonaDto>, IPersonaBusiness
    {
        private readonly IPersonaData _data;
        private readonly IBaseModelData<Rol, RolDto> _dataRol;
        private readonly IUsuarioBusiness _businessUsuario;
        private readonly IBaseModelBusiness<UsuarioRol, UsuarioRolDto> _businessUsuarioRol;
        private readonly IMapper _mapper;

        public PersonaBusiness(IPersonaData data,
            IBaseModelData<Rol, RolDto> dataRol,
            IUsuarioBusiness businessUsuario,
            IBaseModelBusiness<UsuarioRol, UsuarioRolDto> businessUsuarioRol,
            IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _dataRol = dataRol;
            _businessUsuario = businessUsuario;
            _businessUsuarioRol = businessUsuarioRol;
            _mapper = mapper;
        }

        public override async Task<PersonaDto> Save(PersonaDto personaDto)
        {
            Persona personaExistente = await _data.GetByDocument(personaDto.Documento);

            if (personaExistente != null)
            {
                throw new Exception("¡Ya existe una persona con el mismo documento!");
            }

            //Creo la persona
            personaDto.CreateAt = DateTime.UtcNow.AddHours(-5);
            Persona persona = _mapper.Map<Persona>(personaDto);
            persona = await _data.Save(persona);

            //Valido que la persona no sea un cliente para no crearle un usuario en el sistema
            if (!personaDto.Cliente)
            {
                //Creo el usuario con la persona que acabamos de crear
                UsuarioDto usuarioDto = new UsuarioDto()
                {
                    Id = 0,
                    Activo = true,
                    CreateAt = DateTime.UtcNow.AddHours(-5),
                    UserName = persona.Email,
                    Password = persona.Documento,
                    PersonaId = persona.Id,
                };

                usuarioDto = await _businessUsuario.Save(usuarioDto);

                //Consulto el rol de cajero
                Rol rol = await _dataRol.GetByCode("CAJA");

                //Le asocio un rol al usuario
                UsuarioRolDto usuarioRolDto = new UsuarioRolDto()
                {
                    Id = 0,
                    Activo = true,
                    CreateAt = DateTime.UtcNow.AddHours(-5),
                    UsuarioId = usuarioDto.Id,
                    RolId = rol.Id,
                };

                _ = await _businessUsuarioRol.Save(usuarioRolDto);
            }

            return _mapper.Map<PersonaDto>(persona);
        }
    }
}
