﻿using BTT.Domain.Common.Events;
using BTT.Domain.Models.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Models.Members
{
    public class MemberIsNotified : IDomainEvent<INotification>
    {
        public Guid EventId { get; }

        public DateTime EventDateOccured { get; }

        public INotification Data { get; }

        public MemberIsNotified(INotification notification)
        {
            this.Data = notification;
            this.EventId = Guid.NewGuid();
            this.EventDateOccured = DateTime.Now;
        }
    }
}