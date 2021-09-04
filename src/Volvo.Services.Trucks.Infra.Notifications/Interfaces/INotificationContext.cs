using System.Collections.Generic;

namespace Volvo.Services.Trucks.Infra.Notifications.Interfaces
{
    public interface INotificationContext
    {
        List<Notification> Notifications { get;}

        bool HasNotifications { get; }

        void AddNotification(string message);

        void AddNotification(string key, string message);

        void AddNotification(Notification notification);
        void AddNotifications(IList<Notification> notifications);

        void AddNotifications(ICollection<Notification> notifications);

        void AddNotifications(IEnumerable<Notification> notifications);

        void AddNotifications(ICollection<string> notifications);

        void AddNotifications(IEnumerable<string> notifications);
        void ClearNotifications();

    }
}