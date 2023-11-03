using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExpenseTracker.Domain.Primitives
{
    public struct Maybe<T> : IEquatable<Maybe<T>> where T : class
    {
        private readonly T _value;
        public T Value
        {
            get
            {
                if (HasNoValue)
                {
                    throw new InvalidOperationException();
                }
                return _value;
            }
        }
        public bool HasValue => _value != null;
        public bool HasNoValue => !HasValue;
        public Maybe(T value)
        {
            _value = value;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Maybe<T>))
            {
                return false;
            }
            var other = (Maybe<T>)obj;

            return Equals(other);
        }

        public bool Equals(Maybe<T> other)
        {
            if (HasNoValue && other.HasNoValue)
            {
                return true;
            }
            if (HasNoValue || other.HasNoValue)
            {
                return false;
            }
            return _value.Equals(other._value);
        }
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
        public static bool operator ==(Maybe<T> maybe, T value)
        {
            return maybe.HasValue && maybe.Value.Equals(value);
        }
        public static bool operator !=(Maybe<T> maybe, T value)
        {
            return !(maybe == value);
        }
        public static bool operator ==(Maybe<T> first, Maybe<T> second)
        {
            return first.Equals(second);
        }
        public static bool operator !=(Maybe<T> first, Maybe<T> second)
        {
            return !(first == second);
        }
        public static implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }
        public T Unwrap()
        {
            return HasValue ? Value : default;
        }

        public TProperty Unwrap<TProperty>(Func<T, TProperty> selector)
        {
            return HasValue ? selector(Value) : default;
        }
    }
}
