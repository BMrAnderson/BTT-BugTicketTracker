using BTT.Domain.Common.Events;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BTT.Domain.Common
{
    public interface IEntity
    {
        IProducerConsumerCollection<IDomainEvent> DomainEvents { get; }

        void ClearAllEvents();
    }
}