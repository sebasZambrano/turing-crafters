using AutoMapper;
using Business.Interfaces.Parameter;
using Data.Interfaces;
using Data.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Business.Implementations.Parameter
{
    public class ImpresoraCategoriaBusiness : BaseModelBusiness<ImpresoraCategoria, ImpresoraCategoriaDto>, IImpresoraCategoriaBusiness
    {
        private readonly IImpresoraCategoriaData _data;

        public ImpresoraCategoriaBusiness(IImpresoraCategoriaData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
        }
    }
}
