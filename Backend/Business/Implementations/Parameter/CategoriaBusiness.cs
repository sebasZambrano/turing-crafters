using AutoMapper;
using Business.Interfaces.Parameter;
using Data.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Business.Implementations.Parameter
{
    public class CategoriaBusiness : BaseModelBusiness<Categoria, CategoriaDto>, ICategoriaBusiness
    {
        private readonly ICategoriaData _data;

        public CategoriaBusiness(ICategoriaData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
        }
    }
}
