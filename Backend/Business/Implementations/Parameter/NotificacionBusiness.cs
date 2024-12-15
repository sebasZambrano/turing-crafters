using AutoMapper;
using Business.Interfaces.Parameter;
using Data.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;

namespace Business.Implementations.Parameter
{
    public class NotificacionBusiness : BaseModelBusiness<Notificacion, NotificacionDto>, INotificacionBusiness
    {
        private readonly INotificacionData _data;

        public NotificacionBusiness(INotificacionData data, IMapper mapper) : base(data, mapper)
        {
            _data = data;
        }
    }
}
