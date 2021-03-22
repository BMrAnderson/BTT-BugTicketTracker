using BTT.Domain.Common.Events;
using System;

namespace BTT.Domain.Models.Organizations
{
    public class OrganizationCreated : IDomainEvent
    {
        public Guid EventId { get; }

        public DateTimeOffset EventDateOccured { get; }

        public Organization Organization { get; }

        public OrganizationCreated(Organization organization)
        {
            this.Organization = organization;
            this.EventId = Guid.NewGuid();
            this.EventDateOccured = DateTimeOffset.Now;
        }
    }
}