using ExpenseTracker.Application.Infrastructure;
using ExpenseTracker.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpenseTracker.Application.Abstractions.Specification
{
    public abstract class SpecificationBase<TEntity> : ISpecification<TEntity> where TEntity : Entity
    {
        
        protected SpecificationBase(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
            IncludeExpressions = new List<Expression<Func<TEntity, object>>>();
            IncludeStrings = new List<string>();
        }

        public Expression<Func<TEntity, bool>> Criteria { get; }
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; }
        public List<string> IncludeStrings { get; }
        public Expression<Func<TEntity, object>> OrderByExpression { get; private set; }
        public Expression<Func<TEntity, object>> OrderByDescendingExpression { get; private set; }

        protected virtual void AddInclude(Expression<Func<TEntity, object>> includeExpressions)
        {
            Check.NotNull(includeExpressions, nameof(includeExpressions));

            IncludeExpressions.Add(includeExpressions);
        }

        protected virtual void AddInclude(string includeString)
        {
            Check.NotNullOrEmpty(includeString, nameof(includeString));

            IncludeStrings.Add(includeString);
        }

        protected virtual void ApplyOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            Check.NotNull(orderByExpression, nameof(orderByExpression));

            OrderByExpression = orderByExpression;

            OrderByDescendingExpression = null;
        }

        protected virtual void ApplyOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression)
        {
            Check.NotNull(orderByDescendingExpression, nameof(orderByDescendingExpression));

            OrderByExpression = null;

            OrderByDescendingExpression = orderByDescendingExpression;
        }
    }
}
