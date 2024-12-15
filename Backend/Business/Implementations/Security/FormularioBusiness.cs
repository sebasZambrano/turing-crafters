using AutoMapper;
using Business.Interfaces.Security;
using Data.Interfaces.Security;
using Entity.Dtos.Security;
using Entity.Models.Security;

namespace Business.Implementations.Security
{
    public class FormularioBusiness : BaseModelBusiness<Formulario, FormularioDto>, IFormularioBusiness
    {
        private readonly IFormularioData _data;

        public FormularioBusiness(IFormularioData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
        }
    }
}
