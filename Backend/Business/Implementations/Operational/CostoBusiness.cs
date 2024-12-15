using AutoMapper;
using Business.Interfaces.Operational;
using Data.Interfaces.Inventory;
using Data.Interfaces.Operational;
using Data.Interfaces.Parameter;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Dtos.Operational;
using Entity.Models.Inventory;
using Entity.Models.Operational;
using Entity.Models.Parameter;

namespace Business.Implementations.Operational
{
    public class CostoBusiness : BaseModelBusiness<Costo, CostoDto>, ICostoBusiness
    {
        private readonly ICostoData _data;
        private readonly IEmpleadoData _dataEmpleado;
        private readonly IProveedorData _dataProveedor;
        private readonly IMapper _mapper;

        public CostoBusiness(ICostoData data,
            IEmpleadoData dataEmpleado,
            IProveedorData dataProveedor,
            IMapper mapper) : base(data, mapper)
        {
            _data = data;
            _dataEmpleado = dataEmpleado;
            _dataProveedor = dataProveedor;
            _mapper = mapper;
        }

        public async Task<List<CostoDto>> GetBillsDate(QueryFilterDto filter, string parametro)
        {
            return (List<CostoDto>)await _data.GetBillsDate(filter, parametro);
        }

        public async Task<List<CostoDto>> GetBillsCalendar(QueryFilterDto filter, string parametro)
        {
            return (List<CostoDto>)await _data.GetBillsCalendar(filter, parametro);
        }

        public override async Task<CostoDto> Save(CostoDto dto)
        {
            //Consulto el empleado
            Empleado empleado = await _dataEmpleado.GetById(dto.EmpleadoId);

            //Actualizo el dto
            dto.CreateAt = DateTime.UtcNow.AddHours(-5);
            dto.CajaId = empleado.CajaId;
            if(dto.ProveedorId == 0)
            {
                ProveedorDto proveedor = (await _dataProveedor.GetDataTable(new QueryFilterDto() { })).First();
                dto.ProveedorId = proveedor.Id;
            }

            //Guardo el costo
            Costo costo = _mapper.Map<Costo>(dto);
            costo = await _data.Save(costo);
            return _mapper.Map<CostoDto>(costo);
        }
    }
}
