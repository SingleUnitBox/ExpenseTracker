using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Primitives
{
    public abstract class Enumeration : IComparable
    {
        public int Value { get; }
        public string Name { get; }
        protected Enumeration(int value, string name)
        {
            Value = value;
            Name = name;
        }
        public int CompareTo(object other)
        {
            return Value.CompareTo(((Enumeration)other).Value);
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Enumeration otherValue))
            {
                return false;
            }
            return GetType() == obj.GetType() && otherValue.Value.Equals(Value);
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
