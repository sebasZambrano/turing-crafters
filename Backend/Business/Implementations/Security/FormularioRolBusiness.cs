using AutoMapper;
using Business.Interfaces.Security;
using Data.Interfaces.Security;
using Entity.Dtos;
using Entity.Dtos.Security;
using Entity.Models.Security;

namespace Business.Implementations.Security
{
    public class FormularioRolBusiness : BaseModelBusiness<FormularioRol, FormularioRolDto>, IFormularioRolBusiness
    {
        private readonly IFormularioRolData _data;
        private readonly IMapper _mapper;


        public FormularioRolBusiness(IFormularioRolData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public override async Task<FormularioRolDto> Save(FormularioRolDto dto)
        {
            var exist = false;

            QueryFilterDto filters = new QueryFilterDto()
            {
                ForeignKey = dto.RolId,
                NameForeignKey = "RolId"
            };

            IEnumerable<FormularioRolDto> lstFormularioRolDto = await _data.GetDataTable(filters);

            if (lstFormularioRolDto.Count() > 0)
            {
                foreach (var item in lstFormularioRolDto)
                {
                    if (item.RolId == dto.RolId && item.FormularioId == dto.FormularioId)
                    {
                        exist = true;
                    }
                }
            }

            if (exist)
            {
                throw new Exception("El formulario ya está asociado al rol!");
            }

            FormularioRol entity = _mapper.Map<FormularioRol>(dto);
            entity = await _data.Save(entity);
            return _mapper.Map<FormularioRolDto>(entity);
        }
    }
}
