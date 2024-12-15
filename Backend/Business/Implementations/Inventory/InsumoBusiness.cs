using AutoMapper;
using Business.Interfaces.Inventory;
using Data.Interfaces.Inventory;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;

namespace Business.Implementations.Inventory
{
    public class InsumoBusiness : BaseModelBusiness<Insumo, InsumoDto>, IInsumoBusiness
    {
        private readonly IInsumoData _data;

        public InsumoBusiness(IInsumoData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
        }
    }
}
