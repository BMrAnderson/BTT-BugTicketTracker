using BTT.Domain.Common.Events;
using System;

namespace BTT.Domain.Models.Issues
{
    public class AttachmentAdded : IDomainEvent<Attachment>
    {
        public Guid EventId { get; }

        public DateTime EventDateOccured { get; }

        public Attachment Data { get; }

        public AttachmentAdded(Attachment attachment)
        {
            this.Data = attachment;
            this.EventId = Guid.NewGuid();
            this.EventDateOccured = DateTime.Now;
        }
    }
}