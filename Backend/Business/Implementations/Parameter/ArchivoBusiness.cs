using AutoMapper;
using Business.Interfaces.Parameter;
using Data.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Business.Implementations.Parameter
{
    public class ArchivoBusiness : BaseModelBusiness<Archivo, ArchivoDto>, IArchivoBusiness
    {
        private readonly IArchivoData _data;

        public ArchivoBusiness(IArchivoData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
        }
    }
}
