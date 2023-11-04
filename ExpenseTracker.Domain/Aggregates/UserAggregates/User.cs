using ExpenseTracker.Domain.Aggregates.ExpenseAggregates;
using ExpenseTracker.Domain.Events;
using ExpenseTracker.Domain.Exceptions;
using ExpenseTracker.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Domain.Aggregates.UserAggregates
{
    public sealed class User : AggregateRoot, IAuditableEntity
    {
        private readonly IList<Expense> _expenses;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Email Email { get; private set; }
        public IReadOnlyList<Expense> Expenses => _expenses.ToList();
        public DateTime CreatedOnUtc { get; }
        public DateTime? UpdatedOnOnUtc { get;  }

        public User()
        {
            _expenses = new List<Expense>();
        }
        public User(Guid id, string firstName, string lastName, Email email) : this()
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        public void AddExpense(Expense expense)
        {
            if (expense == null)
            {
                throw new DomainException("Expense cannot be null.");
            }
            Maybe<Expense> expenseOrNothing = GetExpenseIfExists(expense);

            if (expenseOrNothing.HasValue)
            {
                return;
            }
            _expenses.Add(expense);
        }
        public void RemoveExpense(Expense expense)
        {
            if (expense == null)
            {
                throw new DomainException("Expense cannot be null.");
            }

            Maybe<Expense> expenseOrNothing = GetExpenseIfExists(expense);

            if (expenseOrNothing.HasNoValue)
            {
                return;
            }

            _expenses.Remove(expense);
            AddDomainEvent(new ExpenseRemovedEvent(expense.Id));
        }
        private Maybe<Expense> GetExpenseIfExists(Expense expense) => _expenses.SingleOrDefault(e => e.Equals(expense) && !e.Deleted);
    }
}
