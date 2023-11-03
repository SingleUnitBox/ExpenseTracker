using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ExpenseTracker.Domain.Primitives
{
    public abstract class ValueObject
    {
        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }
            return a.Equals(b);
        }
        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            var valueObject = (ValueObject)obj;

            return GetAtomicValues().SequenceEqual(valueObject.GetAtomicValues());
        }
        public override int GetHashCode() 
        {
            var hashCode = new HashCode();

            foreach (object obj in GetAtomicValues())
            {
                hashCode.Add(obj);

            }
            return hashCode.ToHashCode();
        }
        protected abstract IEnumerable<ValueObject> GetAtomicValues();
    }
}
