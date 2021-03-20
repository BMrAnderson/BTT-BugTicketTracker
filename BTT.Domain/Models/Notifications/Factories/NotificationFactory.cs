using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Notifications.Factories
{
    public abstract class NotificationFactory
    {
        public abstract INotification CreateNotification(object message);
    }
}
