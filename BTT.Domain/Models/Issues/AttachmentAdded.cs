﻿using BTT.Domain.Common.Events;
using System;

namespace BTT.Domain.Models.Issues
{
    public class AttachmentAdded : IDomainEvent
    {
        public Guid EventId { get; }

        public DateTimeOffset EventDateOccured { get; }

        public Attachment Attachment { get; }

        public AttachmentAdded(Attachment attachment)
        {
            this.Attachment = attachment;
            this.EventId = Guid.NewGuid();
            this.EventDateOccured = DateTimeOffset.Now;
        }
    }
}