using BTT.Domain.Common.Repository;
using System.Collections.Generic;

namespace BTT.Domain.Models.Notifications
{
    public interface INotificationRepository : IRepository<BaseNotification>
    {
        IEnumerable<BaseNotification> GetNotificationsByColor(object color);
    }
}