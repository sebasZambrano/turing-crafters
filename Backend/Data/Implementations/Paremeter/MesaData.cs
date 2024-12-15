using AutoMapper;
using Data.Interfaces.Parameter;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Paremeter
{
    public class MesaData : BaseModelData<Mesa, MesaDto>, IMesaData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public MesaData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<MesaDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            mesa.Id,
                            mesa.Activo,
                            mesa.CreateAt,
                            mesa.Codigo,
                            mesa.Nombre,
                            mesa.Descripcion,
                            mesa.Cupo,
                            mesa.SalonId,
                            salon.Nombre AS Salon,
                            mesa.EstadoId,
                            estado.Nombre AS Estado
                        FROM
                            Mesas AS mesa
                        INNER JOIN Salones salon ON mesa.SalonId = salon.Id
                        INNER JOIN Estados estado ON mesa.EstadoId = estado.Id
                        WHERE mesa.DeleteAt IS NULL ";

            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND mesa." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(salon.Nombre, mesa.Codigo, mesa.Nombre, estado.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "mesa.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<MesaDto> items = await _applicationContext.QueryAsync<MesaDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

            return items;
        }
    }
}
