using System.Collections;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Volvo.Services.Trucks.Infra.Notifications.Models
{
    public class ErrorResultModel
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<string> Errors { get; set; }

        protected ErrorResultModel()
        { }

        public ErrorResultModel(string message)
        {
            Message = message;
        }

        public ErrorResultModel(string message, IEnumerable<Notification> notifications)
        {
            Message = message;
            Errors = notifications.Select(n => n.Message).ToList();
        }

        public ErrorResultModel(IEnumerable<Notification> notifications)
        {
            Errors = notifications.Select(n => n.Message).ToList();
        }
    }
}
