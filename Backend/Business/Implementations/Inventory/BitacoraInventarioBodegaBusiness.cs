using AutoMapper;
using Business.Interfaces.Inventory;
using Data.Interfaces;
using Data.Interfaces.Inventory;
using Entity.Dtos;
using Entity.Dtos.Inventory;
using Entity.Models.Inventory;

namespace Business.Implementations.Inventory
{
    public class BitacoraInventarioBodegaBusiness : BaseModelBusiness<BitacoraInventarioBodega, BitacoraInventarioBodegaDto>, IBitacoraInventarioBodegaBusiness
    {
        private readonly IBitacoraInventarioBodegaData _data;

        public BitacoraInventarioBodegaBusiness(IBitacoraInventarioBodegaData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
        }

        public async Task<string> GenerarCodigo()
        {
            IEnumerable<BitacoraInventarioBodegaDto> bitacoras = await _data.GetDataTable(new QueryFilterDto { Filter = "" });
            int cantidadBitacoras = bitacoras.Count() + 1;
            string codigo = $"BIB-{DateTime.UtcNow.AddHours(-5).Year}-{cantidadBitacoras.ToString().PadLeft(4, '0')}";
            return codigo;
        }
    }
}
