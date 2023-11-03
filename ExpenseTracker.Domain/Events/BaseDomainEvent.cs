using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Events
{
    public abstract class BaseDomainEvent : IDomainEvent
    {
        public Guid EventId { get; }

        public DateTime OccuredOnUtc { get; }
        protected internal BaseDomainEvent()
        {
            EventId = Guid.NewGuid();
            OccuredOnUtc = DateTime.UtcNow;
        }
    }
}
