using ExpenseTracker.Domain.Extensions;
using ExpenseTracker.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ExpenseTracker.Domain.Aggregates.ExpenseAggregates
{
    
    public sealed class Email : ValueObject
    {
        private const string EmailRegexPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|
            ([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
        public string Value { get; }
        private Email(string email)
        {
            Value = email;
        }
        public static Result<Email> Create(Maybe<string> emailOrNothing)
        {
            return emailOrNothing
                .ToResult("Email should not be empty.")
                .OnSuccess(email => email.Trim())
                .Ensure(email => email != string.Empty, "Email should not be empty")
                .Ensure(email => email.Length < 256, "Email cannot be longer than 265 characters.")
                .Ensure(email => Regex.IsMatch(email, EmailRegexPattern), "Email is invalid.")
                .Map(email => new Email(email));
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
        public static implicit operator string(Email email) => email.Value;
        public static implicit operator Email(string email) => Create(email).Value;
    }
}
