using AutoMapper;
using Business.Interfaces.Security;
using Data.Interfaces.Security;
using Entity.Dtos.Security;
using Entity.Models.Security;

namespace Business.Implementations.Security
{
    public class UsuarioRolBusiness : BaseModelBusiness<UsuarioRol, UsuarioRolDto>, IUsuarioRolBusiness
    {
        private readonly IUsuarioRolData _data; 
        private readonly IMapper _mapper;
        public UsuarioRolBusiness(IUsuarioRolData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _mapper = mapper;
        }
    }
}
