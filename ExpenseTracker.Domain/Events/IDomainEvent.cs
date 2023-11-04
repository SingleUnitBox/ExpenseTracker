using MediatR;
using System;

namespace ExpenseTracker.Domain.Events
{
    public interface IDomainEvent : INotification
    {
        Guid EventId { get; }
        DateTime OccurredOnUtc { get; }
    }
}