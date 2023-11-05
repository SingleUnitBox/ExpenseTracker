using ExpenseTracker.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpenseTracker.Application.Abstractions.Specification
{
    public interface ISpecification<TEntity> where TEntity : Entity
    {
        Expression<Func<TEntity, bool>> Criteria { get; }
        List<Expression<Func<TEntity, object>>> IncludeExpressions { get; }
        List<string> IncludeStrings { get; }
        Expression<Func<TEntity, object>> OrderByExpression { get; }
        Expression<Func<TEntity, object>> OrderByDescendingExpression { get; }
    }
}
