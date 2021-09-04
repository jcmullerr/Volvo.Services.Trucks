using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Volvo.Services.Trucks.Infra.Notifications.Models
{
    public class ErrorResult : ObjectResult
    {
        public ErrorResult(string message, IReadOnlyCollection<Notification> notifications, int statusCode)
          : base(new ErrorResultModel(message, notifications))
        {
            StatusCode = statusCode;
        }
    }
}
