using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Volvo.Services.Trucks.Infra.Notifications.Interfaces;
using Volvo.Services.Trucks.Infra.Notifications.Models;

namespace Volvo.Services.Trucks.Infra.Notifications.Filters
{
    public class CustomNotificationFilter : ActionFilterAttribute
    {
        private readonly INotificationContext _notificationContext;

        public CustomNotificationFilter(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (_notificationContext.HasNotifications)
            {
                context.Result = new ErrorResult(
                    "Houve um erro ao processar sua requisição", 
                    _notificationContext.Notifications, 
                    StatusCodes.Status422UnprocessableEntity
                );
            }
            else
            {
                base.OnActionExecuted(context);
            }
        }

    }
}