using BTT.Domain.Common.Events;
using System;

namespace BTT.Domain.Models.Issues
{
    public class IssueCreated : IDomainEvent<Issue>
    {
        public Guid EventId { get; }

        public DateTime EventDateOccured { get; }

        public Issue Data { get; }

        public IssueCreated(Issue issue)
        {
            this.Data = issue;
            this.EventId = Guid.NewGuid();
            this.EventDateOccured = DateTime.Now;
        }
    }
}