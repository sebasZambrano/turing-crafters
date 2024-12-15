using Business.Interfaces;
using Business.Interfaces.Parameter;
using Entity.Dtos.Parameter;
using Entity.Models.Parameter;
using Web.Controllers.Interfaces.Parameter;

namespace Web.Controllers.Implementations.Parameter
{
    public class NotificacionController : BaseModelController<Notificacion, NotificacionDto>, INotificacionController
    {
        private readonly INotificacionBusiness _business;
        public NotificacionController(IBaseModelBusiness<Notificacion, NotificacionDto> baseBusiness, INotificacionBusiness business) : base(baseBusiness)
        {
            _business = business;
        }
    }
}
