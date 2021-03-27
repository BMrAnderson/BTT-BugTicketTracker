using BTT.Domain.Common.Events;
using BTT.Domain.Common.Validation;
using System;

namespace BTT.Domain.Models.Issues
{
    public class CommentAdded : IDomainEvent
    {
        public Guid EventId { get; }

        public DateTime EventDateOccured { get; }

        public Comment Comment { get; }

        public CommentAdded(Comment comment)
        {
            Validation.CheckNull(comment, nameof(comment));

            this.EventId = Guid.NewGuid();
            this.Comment = comment;
            this.EventDateOccured = DateTime.Now;
        }
    }
}