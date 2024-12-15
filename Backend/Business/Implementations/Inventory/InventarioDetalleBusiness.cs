using AutoMapper;
using Business.Interfaces.Inventory;
using Data.Interfaces.Inventory;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;

namespace Business.Implementations.Inventory
{
    public class InventarioDetalleBusiness : BaseModelBusiness<InventarioDetalle, InventarioDetalleDto>, IInventarioDetalleBusiness
    {
        private readonly IInventarioDetalleData _data;

        public InventarioDetalleBusiness(IInventarioDetalleData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
        }
    }
}
