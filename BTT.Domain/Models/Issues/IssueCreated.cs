using BTT.Domain.Common.Events;
using BTT.Domain.Common.Validation;
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
            Validation.CheckNull(issue, nameof(issue));

            this.Data = issue;
            this.EventId = Guid.NewGuid();
            this.EventDateOccured = DateTime.Now;
        }
    }
}