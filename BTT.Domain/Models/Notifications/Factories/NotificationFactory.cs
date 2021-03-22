namespace BTT.Domain.Models.Notifications.Factories
{
    public abstract class NotificationFactory
    {
        public abstract INotification CreateNotification(object message);
    }
}