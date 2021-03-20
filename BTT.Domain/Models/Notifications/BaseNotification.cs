using BTT.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Notifications
{
    public abstract class BaseNotification : INotification, IAggregateRoot
    {
        public object Id { get; protected set; }
       
        public object MemberNotifiedId { get; protected set; }
        
        public object NotificationColor { get; protected set; }
        
        public DateTimeOffset DateReceived { get; protected set; }
        
        public string Text { get; protected set; }

        public BaseNotification() { }

        public BaseNotification(object id, object memberNotifiedId, object notificationColor, DateTimeOffset dateReceived, string text)
        {
            this.Id = id;
            this.MemberNotifiedId = memberNotifiedId;
            this.NotificationColor = notificationColor;
            this.DateReceived = dateReceived;
            this.Text = text;
        }

        public virtual void Send(string message)
        {
            Text = message;
        }
    }
}
