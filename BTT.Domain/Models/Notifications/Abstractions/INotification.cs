namespace BTT.Domain.Models.Notifications
{
    public interface INotification
    {
        string Text { get; }

        void Send(string message);
    }
}