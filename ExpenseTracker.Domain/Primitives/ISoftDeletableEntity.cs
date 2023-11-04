using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Primitives
{
    public interface ISoftDeletableEntity
    {
        bool Deleted { get; }
        DateTime? DeletedOnUtc { get; }
    }
}
