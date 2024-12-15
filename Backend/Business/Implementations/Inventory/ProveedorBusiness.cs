using AutoMapper;
using Business.Interfaces.Inventory;
using Data.Interfaces.Inventory;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;

namespace Business.Implementations.Inventory
{
    public class ProveedorBusiness : BaseModelBusiness<Proveedor, ProveedorDto>, IProveedorBusiness
    {
        private readonly IProveedorData _data;
        private readonly IMapper _mapper;

        public ProveedorBusiness(IProveedorData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _mapper = mapper;
        }
    }
}
