using AutoMapper;
using Data.Interfaces.Parameter;
using Entity.Contexts;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Paremeter
{
    public class ArchivoData : BaseModelData<Archivo, ArchivoDto>, IArchivoData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public ArchivoData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Archivo> GetByTablaId(int id, string nombre)
        {
            var sql = @"SELECT
                            *
                        FROM Archivos
                        WHERE TablaId = @Id AND Tabla = @Nombre";
            return await _applicationContext.QueryFirstOrDefaultAsync<Archivo>(sql, new { Id = id, Nombre = nombre });
        }
    }
}
