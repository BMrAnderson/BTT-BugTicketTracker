using BTT.Domain.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Notifications
{
    public interface INotificationRepository : IRepository<BaseNotification>
    {
        IEnumerable<BaseNotification> GetNotificationsByColor(object color);
    }
}
