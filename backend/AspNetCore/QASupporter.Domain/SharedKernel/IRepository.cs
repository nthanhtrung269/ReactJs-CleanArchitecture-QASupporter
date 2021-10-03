using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QASupporter.Domain.SharedKernel
{
    public interface IRepository<T, TId> where T : Entity<TId>, IAggregateRoot
    {
        Task<T> GetAsync(object id);
        Task<T> GetByIdAsync(TId id);
        Task<List<T>> ListAsync();
        Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddAndSaveChangesAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateAndSaveChangesAsync(T entity);
        Task ReloadAsync(T entity);
        Task LoadCollectionAsync(T entity, string propertyName);
        Task CommitAsync();
        Task CommitAndReloadAsync(T entity);
    }
}
