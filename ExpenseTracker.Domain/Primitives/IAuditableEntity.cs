using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Primitives
{
    public interface IAuditableEntity
    {
        DateTime CreatedOnUtc { get; }
        DateTime? UpdatedOnOnUtc { get; }
    }
}
