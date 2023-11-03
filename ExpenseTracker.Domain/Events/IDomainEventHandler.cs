using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Events
{
    public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
        where TDomainEvent : IDomainEvent
    {
    }
}
