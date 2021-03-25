using System;

namespace BTT.Domain.Common.Events
{
    public interface IDomainEvent<T> where T : class
    {
        public Guid EventId { get; }

        public DateTime EventDateOccured { get; }

        public T Data { get; }
    }
}