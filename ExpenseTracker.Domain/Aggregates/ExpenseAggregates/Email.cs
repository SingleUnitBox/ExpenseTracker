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
        public static Result<Email> Create(string email)
        {
            email = (email ?? string.Empty).Trim();

            if (email.Length == 0)
            {
                return Result.Fail<Email>("Email should not be empty.");
            }

            bool isRegexMatch = Regex.IsMatch(email, EmailRegexPattern, RegexOptions.IgnoreCase);

            return isRegexMatch ? Result.Ok(new Email(email)) : Result.Fail<Email>("Email is invalid.");
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
        public static implicit operator string(Email email) => email.Value;
        public static implicit operator Email(string email) => Create(email).Value;
    }
}
