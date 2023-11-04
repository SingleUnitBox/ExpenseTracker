using ExpenseTracker.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain.Abstractions
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        Task<Maybe<TAggregateRoot>> GetByIdAsync(Guid id);
    }
}
