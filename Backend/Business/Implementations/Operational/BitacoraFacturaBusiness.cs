using AutoMapper;
using Business.Interfaces.Operational;
using Data.Interfaces.Operational;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Models.Operational;

namespace Business.Implementations.Operational
{
    public class BitacoraFacturaBusiness : BaseModelBusiness<BitacoraFactura, BitacoraFacturaDto>, IBitacoraFacturaBusiness
    {
        private readonly IBitacoraFacturaData _data;

        public BitacoraFacturaBusiness(IBitacoraFacturaData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
        }

        public async Task<string> GenerarCodigo()
        {
            IEnumerable<BitacoraFacturaDto> bitacoras = await _data.GetDataTable(new QueryFilterDto { Filter = "" });
            int cantidadBitacoras = bitacoras.Count() + 1;
            string codigo = $"BI-{DateTime.UtcNow.AddHours(-5).Year}-{cantidadBitacoras.ToString().PadLeft(4, '0')}";
            return codigo;
        }
    }
}
