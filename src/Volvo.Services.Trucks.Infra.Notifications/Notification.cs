namespace Volvo.Services.Trucks.Infra.Notifications
{
    public class Notification
    {
        public string Key { get; private set; }
        public string Message { get; private set; }

        public Notification(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public Notification(string message)
        {
            Message = message;
        }
    }
}