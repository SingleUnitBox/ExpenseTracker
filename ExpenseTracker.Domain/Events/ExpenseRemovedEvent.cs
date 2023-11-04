using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Events
{
    public sealed class ExpenseRemovedEvent : BaseDomainEvent
    {
        public Guid ExpenseId { get; }
        public ExpenseRemovedEvent(Guid expenseId)
        {
            ExpenseId = expenseId;
        }
    }
}
