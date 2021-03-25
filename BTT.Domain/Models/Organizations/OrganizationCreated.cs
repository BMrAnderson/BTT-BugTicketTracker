using BTT.Domain.Common.Events;
using BTT.Domain.Common.Extensions;
using System;

namespace BTT.Domain.Models.Organizations
{
    public class OrganizationCreated : IDomainEvent<Organization>
    {
        public Guid EventId { get; }

        public DateTime EventDateOccured { get; }

        public Organization Data { get; }

        public OrganizationCreated(Organization organization)
        {
            organization.CheckNull(nameof(organization));

            this.Data = organization;
            this.EventId = Guid.NewGuid();
            this.EventDateOccured = DateTime.Now;
        }
    }
}