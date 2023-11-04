using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Events
{
    public abstract class BaseDomainEvent : IDomainEvent
    {
        public Guid EventId { get; }

        public DateTime OccurredOnUtc { get; }
        protected internal BaseDomainEvent()
        {
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}
