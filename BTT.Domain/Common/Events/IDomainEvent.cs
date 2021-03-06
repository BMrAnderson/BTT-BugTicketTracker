using System;

namespace BTT.Domain.Common.Events
{
    public interface IDomainEvent
    {
        public Guid EventId { get; }

        public DateTime EventDateOccured { get; }
    }
}