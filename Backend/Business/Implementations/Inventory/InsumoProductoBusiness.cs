using AutoMapper;
using Business.Interfaces.Inventory;
using Data.Interfaces.Inventory;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;

namespace Business.Implementations.Inventory
{
    public class InsumoProductoBusiness : BaseModelBusiness<InsumoProducto, InsumoProductoDto>, IInsumoProductoBusiness
    {
        private readonly IInsumoProductoData _data;
        private readonly IMapper _mapper;

        public InsumoProductoBusiness(IInsumoProductoData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public override async Task<InsumoProductoDto> Save(InsumoProductoDto dto)
        {
            var exist = false;

            QueryFilterDto filters = new QueryFilterDto()
            {
                ForeignKey = dto.ProductoId,
                NameForeignKey = "ProductoId"
            };

            IEnumerable<InsumoProductoDto> lstInsumoProducto = await _data.GetDataTable(filters);

            if (lstInsumoProducto.Count() > 0)
            {
                foreach (var item in lstInsumoProducto)
                {
                    if (item.ProductoId == dto.ProductoId && item.InsumoId == dto.InsumoId)
                    {
                        exist = true;
                    }
                }
            }

            if (exist)
            {
                throw new Exception("El insumo ya está asociado al producto!");
            }

            InsumoProducto entity = _mapper.Map<InsumoProducto>(dto);
            entity = await _data.Save(entity);
            return _mapper.Map<InsumoProductoDto>(entity);
        }

        public async Task<List<DetalleInventarioBodegaDto>> GetOrdenDetalle(QueryFilterDto filters)
        {
            return (List<DetalleInventarioBodegaDto>)await _data.GetOrdenDetalle(filters);

        }
    }
}
