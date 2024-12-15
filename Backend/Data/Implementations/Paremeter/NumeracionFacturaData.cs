using AutoMapper;
using Data.Interfaces.Parameter;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Operational;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Paremeter
{
    public class NumeracionFacturaData : BaseModelData<NumeracionFactura, NumeracionFacturaDto>, INumeracionFacturaData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public NumeracionFacturaData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public async Task<IEnumerable<NumeracionFacturaDto>> GetByTipoActiva(string codigo)
        {
            var sql = @"SELECT *
                        FROM
                            NumeracionesFacturas
                        WHERE DeleteAt IS NULL AND Codigo = @codigo AND Activo = 1";

            IEnumerable<NumeracionFacturaDto> items = await _applicationContext.QueryAsync<NumeracionFacturaDto>(sql, new { codigo = codigo });

            return items;
        }
    }
}
