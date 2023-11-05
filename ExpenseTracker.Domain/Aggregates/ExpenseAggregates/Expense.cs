using ExpenseTracker.Domain.Exceptions;
using ExpenseTracker.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace ExpenseTracker.Domain.Aggregates.ExpenseAggregates
{
    public class Expense : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
    {
        private DateTime _date;
        public Guid UserId { get; private set; }
        public Money Money { get; private set; }
        public DateTime Date
        {
            get => _date;
            private set => _date = value.Date;
        }
        public Expense(Guid id, Money money, DateTime date)
        {
            Id = id;
            Money = money;
            Date = date;
        }
        public bool Deleted { get; }

        public DateTime? DeletedOnUtc { get; }

        public DateTime CreatedOnUtc { get; }

        public DateTime? UpdatedOnOnUtc { get; }
        public void ChangeAmount(decimal amount)
        {
            if (amount < decimal.Zero)
            {
                throw new DomainException("Amount cannot be less than zero.");
            }
            Money = Money.ChangeAmount(amount);
        }
        public void ChangeCurrency(Currency currency)
        {
            if (currency == null)
            {
                throw new DomainException("Currency cannot be null.");
            }
            Money = Money.ChangeCurrency(currency);
        }
    }
}
