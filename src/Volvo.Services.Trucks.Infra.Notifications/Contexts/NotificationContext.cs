using System.Collections.Generic;
using System.Linq;
using Volvo.Services.Trucks.Infra.Notifications.Interfaces;

namespace Volvo.Services.Trucks.Infra.Notifications.Contexts
{
    public class NotificationContext : INotificationContext
    {
        public List<Notification> Notifications {get; private set;}

        public bool HasNotifications => Notifications.Any();

        public NotificationContext()
        {
            Notifications = new List<Notification>();
        }

        public void AddNotification(string message)
        {
            Notifications.Add(new Notification(message));
        }

        public void AddNotification(string key, string message)
        {
            Notifications.Add(new Notification(key, message));
        }

        public void AddNotification(Notification notification)
        {
            Notifications.Add(notification);
        }

        public void AddNotifications(IList<Notification> notifications)
        {
            Notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<Notification> notifications)
        {
            Notifications.AddRange(notifications);
        }
        public void AddNotifications(IEnumerable<Notification> notifications)
        {
            Notifications.AddRange(notifications);
        }

        public void AddNotifications(IEnumerable<string> notifications)
        {
            if (notifications == null)
                return;
            foreach (var notification in notifications)
            {
                AddNotification(notification);
            }
        }

        public void AddNotifications(ICollection<string> notifications)
        {
            if (notifications == null)
                return;

            foreach (var notification in notifications)
            {
                AddNotification(notification);
            }
        }

        public void ClearNotifications()
        {
            Notifications.Clear();
        }
    }
}