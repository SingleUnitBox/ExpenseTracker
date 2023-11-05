using ExpenseTracker.Application.Abstractions.Specification;
using ExpenseTracker.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Abstractions
{
    public interface IDbContext
    {
        Task<TEntity> GetByIdAsync<TEntity>(object id) where TEntity : Entity;
        Task<TEntity> GetBySpecificationAsync<TEntity>(ISpecification<TEntity> specification) where TEntity : Entity;
        Task<IEnumerable<TEntity>> ListAsync<TEntity>() where TEntity : Entity;
        Task<IEnumerable<TEntity>> ListBySpecificationAsync<TEntity>(ISpecification<TEntity> specification) where TEntity : Entity;
        Task<int> CountAsync<TEntity>() where TEntity : Entity;
        Task<int> CountBySpecificationAsync<TEntity>(ISpecification<TEntity> specification) where TEntity : Entity;
        void Insert<TEntity>(TEntity entity) where TEntity : Entity;
        void Insert<TEntity>(IEnumerable<TEntity> entities) where TEntity : Entity;
        void Delete<TEntity>(TEntity entity) where TEntity : Entity;
        void Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : Entity;
        IQueryable<TEntity> Table<TEntity>() where TEntity : Entity;
        IQueryable<TEntity> TableAsNoTracking<TEntity>() where TEntity : Entity;
    }
}
