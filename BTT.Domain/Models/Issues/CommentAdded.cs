using BTT.Domain.Common.Events;
using System;

namespace BTT.Domain.Models.Issues
{
    public class CommentAdded : IDomainEvent<Comment>
    {
        public Guid EventId { get; }

        public DateTime EventDateOccured { get; }

        public Comment Data { get; }

        public CommentAdded(Comment comment)
        {
            this.EventId = Guid.NewGuid();
            this.Data = comment;
            this.EventDateOccured = DateTime.Now;
        }
    }
}