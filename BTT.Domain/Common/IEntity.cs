using BTT.Domain.Common.Events;
using System.Collections.Generic;

namespace BTT.Domain.Common
{
    public interface IEntity
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        void ClearAllEvents();
    }
}