using AutoMapper;
using Data.Interfaces.Security;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Security;
using Entity.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Security
{
    public class PersonaData : BaseModelData<Persona, PersonaDto>, IPersonaData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public PersonaData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<PersonaDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            per.Id,
                            per.Activo,
                            per.CreateAt,
                            per.TipoDocumento,
                            per.Documento,
                            per.PrimerNombre,
                            per.SegundoNombre,
                            per.PrimerApellido,
                            per.SegundoApellido,
                            per.Direccion,
                            per.Telefono,
                            per.Email,
                            per.Genero,
                            per.CiudadId,
                            ciu.Nombre AS Ciudad
                        FROM
                            Personas AS per
                        INNER JOIN Ciudades ciu ON per.CiudadId = ciu.Id                       
                        WHERE per.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND per." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(per.Documento, per.PrimerNombre, per.SegundoNombre, per.PrimerApellido, per.SegundoApellido)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "per.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<PersonaDto> items = await _applicationContext.QueryAsync<PersonaDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }

        public async Task<Persona> GetByDocument(string documento)
        {
            // Lógica para obtener un elemento por code
            // Puedes implementar esto en clases concretas
            return await _context.Set<Persona>().FirstOrDefaultAsync(e => EF.Property<string>(e, "Documento") == documento);
        }
    }
}