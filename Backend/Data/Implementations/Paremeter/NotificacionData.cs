using AutoMapper;
using Data.Interfaces.Parameter;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Microsoft.Extensions.Configuration;

namespace Data.Implementations.Paremeter
{
    public class NotificacionData : BaseModelData<Notificacion, NotificacionDto>, INotificacionData
    {
        protected readonly ApplicationDbContext _applicationContext;

        public NotificacionData(ApplicationDbContext applicationContext, IConfiguration configuration, IMapper mapper) : base(applicationContext, configuration, mapper)
        {
            _applicationContext = applicationContext;
        }

        public override async Task<IEnumerable<NotificacionDto>> GetDataTable(QueryFilterDto filters)
        {
            var sql = @"SELECT
                            *
                        FROM Notificaciones AS noti
                        WHERE noti.DeleteAt IS NULL AND 
                        YEAR(noti.CreateAt) = YEAR(@FechaActual) AND
						MONTH(noti.CreateAt) = MONTH(@FechaActual) AND 
						DAY(noti.CreateAt) = DAY(@FechaActual) ";


            if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
            {
                sql += @"AND noti." + filters.NameForeignKey + " = @foreignKey ";
            }

            if (!string.IsNullOrEmpty(filters.Filter))
            {
                sql += "AND (UPPER(CONCAT(noti.Titulo)) LIKE UPPER(CONCAT('%', @filter, '%'))) ORDER BY " + (filters.ColumnOrder ?? "noti.Id") + " " + (filters.DirectionOrder ?? "asc");
            }

            IEnumerable<NotificacionDto> items = await _applicationContext.QueryAsync<NotificacionDto>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey, FechaActual = DateTime.UtcNow.AddHours(-5)});

            return items;
        }
    }
}
