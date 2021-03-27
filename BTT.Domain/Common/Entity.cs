using BTT.Domain.Common.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace BTT.Domain.Common.Models
{
    public abstract class Entity : IEntity
    {
        public virtual Guid Id { get; protected set; }

        private readonly ConcurrentQueue<IDomainEvent> _domainEvents;

        public IProducerConsumerCollection<IDomainEvent> DomainEvents
        {
            get => _domainEvents;
        }

        protected void PublishEvent(IDomainEvent @event)
        {
            _domainEvents.Enqueue(@event);
        }

        public void ClearAllEvents()
        {
            _domainEvents?.Clear();
        }

        public override bool Equals(object obj)
        {
            if (obj is not Entity other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (this.GetType() != other.GetType())
                return false;

            if (this.Id.Equals(default) || other.Id.Equals(default))
                return false;

            return this.Id.Equals(other.Id);
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right) => !(left == right);

        public override int GetHashCode() =>
            this.GetType().ToString()
            .Concat(this.Id.ToString())
            .GetHashCode();
    }
}