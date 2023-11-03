using ExpenseTracker.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Primitives
{
    public class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public virtual IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;
        public virtual void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
        protected virtual void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
