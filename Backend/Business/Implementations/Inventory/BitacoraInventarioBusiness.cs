using AutoMapper;
using Business.Interfaces.Inventory;
using Data.Interfaces.Inventory;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;

namespace Business.Implementations.Inventory
{
    public class BitacoraInventarioBusiness : BaseModelBusiness<BitacoraInventario, BitacoraInventarioDto>, IBitacoraInventarioBusiness
    {
        private readonly IBitacoraInventarioData _data;

        public BitacoraInventarioBusiness(IBitacoraInventarioData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
        }

        public async Task<string> GenerarCodigo()
        {
            IEnumerable<BitacoraInventarioDto> bitacoras = await _data.GetDataTable(new QueryFilterDto { Filter = "" });
            int cantidadBitacoras = bitacoras.Count() + 1;
            string codigo = $"BI-{DateTime.UtcNow.AddHours(-5).Year}-{cantidadBitacoras.ToString().PadLeft(4, '0')}";
            return codigo;
        }
    }
}
