using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Notifications
{
    public class BaseDomainNotification : INotification
    {
        public BaseDomainNotification(string message)
        {
            this.Id = Guid.NewGuid();
            this.Message = message;
            DateCreated = DateTime.Now;
        }

        public Guid Id { get; }

        public string Message { get; protected set; }

        public DateTime DateCreated { get; protected set; }

        public virtual void SetMessage(string message)
        {
            this.Message = message;
        }

        public virtual void SetDateCreated(DateTime dateCreated)
        {
            this.DateCreated = dateCreated;
        }
    }
}
