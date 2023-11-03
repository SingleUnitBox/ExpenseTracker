using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Primitives
{
    public abstract class Entity
    {
        private const int HashMultiplier = 41;
        public Guid Id { get; protected set; }
        public static bool operator ==(Entity a, Entity b)
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
        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);  
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Entity other))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            if (Id == Guid.Empty || other.Id == Guid.Empty)
            {
                return false;
            }
            return Id == other.Id;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode() * HashMultiplier;
        }
    }
}
