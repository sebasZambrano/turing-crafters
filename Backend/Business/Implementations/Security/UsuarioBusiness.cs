using AutoMapper;
using Business.Interfaces.Security;
using Data.Interfaces.Security;
using Entity.Dtos;
using Entity.Dtos.Security;
using Entity.Models.Security;
using Utilities.Interfaces;

namespace Business.Implementations.Security
{
    public class UsuarioBusiness : BaseModelBusiness<Usuario, UsuarioDto>, IUsuarioBusiness
    {
        private readonly IUsuarioData _data;
        private readonly IPersonaData _dataPersona;
        private readonly IMapper _mapper;
        private readonly IJwtAuthenticationService _jwtAuthenticationService;
        public UsuarioBusiness(IUsuarioData data, IPersonaData dataPersona, IJwtAuthenticationService jwtAuthenticationService, IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _dataPersona = dataPersona;
            _jwtAuthenticationService = jwtAuthenticationService;
            _mapper = mapper;
        }

        private async Task<IEnumerable<MenuDto>> GetRecursiveMenu(IEnumerable<MenuDto> data, int userId)
        {
            foreach (var item in data)
            {
                item.Formularios = await _data.GetFormularioMenu(userId, item.ModuloId);
                //item.Modulos = await this.GetRecursiveMenu(await _data.GetDataMenu(), userId);
            }

            return data;
        }

        public override async Task<UsuarioDto> Save(UsuarioDto dto)
        {
            IEnumerable<UsuarioDto> usuarios = await _data.GetDataTable(new QueryFilterDto() { ForeignKey = dto.PersonaId, NameForeignKey = "PersonaId" });

            if (usuarios.Count() > 0)
            {
                throw new Exception("¡Ya existe un usuario asociado a la misma persona!");
            }

            dto.CreateAt = DateTime.UtcNow.AddHours(-5);
            Usuario entity = _mapper.Map<Usuario>(dto);
            entity = await _data.Save(entity);
            return _mapper.Map<UsuarioDto>(entity);
        }

        public override async Task Update(UsuarioDto dto)
        {
            Persona persona = await _dataPersona.GetById(dto.PersonaId);

            IEnumerable<UsuarioDto> usuarios = await _data.GetDataTable(new QueryFilterDto() { ForeignKey = persona.Id, NameForeignKey = "PersonaId" });

            if (usuarios.Count() > 0)
            {
                if (persona.Email != usuarios.First().UserName)
                {
                    throw new Exception("¡Ya existe un usuario asociado a la misma persona!");
                }
            }

            dto.CreateAt = DateTime.UtcNow.AddHours(-5);
            Usuario entity = _mapper.Map<Usuario>(dto);
            entity.UpdateAt = DateTime.UtcNow.AddHours(-5);
            await _data.Update(entity);
        }

        public async Task<Object> Authentication(string Username, string Password)
        {
            var encodePassword = _jwtAuthenticationService.EncryptMD5(Password);
            if (string.IsNullOrEmpty(Username))
            {
                throw new Exception("Usuario vacío");
            }

            if (string.IsNullOrEmpty(Password))
            {
                throw new Exception("Contraseña vacía");
            }

            UsuarioDto user = await _data.GetByUserName(Username);

            if (user == null)
            {
                throw new Exception("No existe el usuario ingresado");
            }

            if (user.Password.ToUpper() != encodePassword.ToUpper())
            {
                throw new Exception("La contraseña es incorrecta");
            }

            if (!user.Activo)
            {
                throw new Exception("El usurio se encuentra inactivo");
            }

            // Si llega hasta aqui llamamos la utilidad de generar token
            var token = _jwtAuthenticationService.Authenticate(Username, encodePassword);


            IEnumerable<MenuDto> data = await _data.GetDataMenu();
            foreach (var item in data)
            {
                item.Formularios = await _data.GetFormularioMenu(user.Id, item.ModuloId);
                //item.Modulos = await this.GetRecursiveMenu(await _data.GetDataMenu(), user.Id);
            }

            return new
            {
                Menus = data,
                Token = token,
                User = user
            };
        }

        public async Task UpdatePassword(UsuarioChangePasswordDto dataUser)
        {
            Usuario user = await _data.GetById(dataUser.Id);

            if (user == null)
            {
                throw new Exception("Usuario no existe");
            }

            if (dataUser.Password != dataUser.PasswordRepeat)
            {
                throw new Exception("Contraseñas no coinciden");
            }

            user.Password = _jwtAuthenticationService.EncryptMD5(dataUser.Password);

            await _data.Update(user);
        }
    }
}
