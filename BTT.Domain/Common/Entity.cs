using BTT.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Domain.Common.Models
{
    public abstract class Entity : IEntity
    {
        public Entity()
        {
            //_domainEvents = new List<IDomainEvent>();
        }

        public virtual Guid Id { get; protected set; }

        //private List<IDomainEvent> _domainEvents;

        //public IReadOnlyCollection<IDomainEvent> DomainEvents { 
        //    get => _domainEvents.AsReadOnly(); 
        //}

        //public void AddDomainEvent(IDomainEvent domainEvent)
        //{
        //    _domainEvents = _domainEvents ?? new List<IDomainEvent>();
        //    _domainEvents.Add(domainEvent);
        //}

        //public void RemoveDomainEventById(Guid id)
        //{
        //    _domainEvents?.RemoveAll(e => e.EventId == id);
        //}

        //public void RemoveDomainEvent(IDomainEvent domainEvent)
        //{
        //    _domainEvents?.Remove(domainEvent);
        //}

        //public void ClearAllEvents()
        //{
        //    _domainEvents?.Clear();
        //}

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
