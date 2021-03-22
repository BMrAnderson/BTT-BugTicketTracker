using BTT.Domain.Common.Events;
using System;

namespace BTT.Domain.Models.Issues
{
    public class IssueCreated : IDomainEvent
    {
        public Guid EventId { get; }

        public DateTimeOffset EventDateOccured { get; }

        public Issue Issue { get; }

        public IssueCreated(Issue issue)
        {
            this.Issue = issue;
            this.EventId = Guid.NewGuid();
            this.EventDateOccured = DateTimeOffset.Now;
        }
    }
}