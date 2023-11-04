using ExpenseTracker.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Aggregates.ExpenseAggregates
{
    public sealed class Money : ValueObject
    {
        public decimal Amount { get; }
        public Currency Currency { get; }
        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
