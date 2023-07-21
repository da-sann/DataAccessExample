using System;
using System.Linq.Expressions;
using DataAccessExample.Interfaces.Entities;

namespace DataAccessExample.Interfaces.Uow
{
    public interface IListIUnitOfWork<out TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
    }
    public interface IUnitOfWork<TEntity, TKey> : IListIUnitOfWork<TEntity>, IDisposable where TEntity : class, IEntity<TKey>
    {
        #region Methods
        bool Any(TKey id);
        bool Any(Expression<Func<TEntity, bool>> criteria);
        int Count();
        int Count(Expression<Func<TEntity, bool>> criteria);
        TEntity GetById(TKey id);
        TEntity Find(TKey id);
        IQueryable<TEntity> GetQueryById(TKey id);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> criteria);
        void Add(TEntity entity);
        TEntity Update(TKey id, Action<TEntity> func, params Expression<Func<TEntity, dynamic>>[] propertyToUpdate);
        void Delete(TKey id);
        void Delete(TEntity entity);
        void Save();
        void RemoveRange(Expression<Func<TEntity, bool>> criteria);
        void Attach(TEntity entity);
        #endregion

        #region Async Methods
        Task<bool> AnyAsync(TKey id, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> criteria, CancellationToken cancellationToken = default);
        Task<int> CountAsync(CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> criteria, CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
        Task<TEntity> FindAsync(TKey id, CancellationToken cancellationToken);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        Task SaveAsync(CancellationToken cancellationToken = default);
        Task RemoveRangeAsync(Expression<Func<TEntity, bool>> criteria, CancellationToken cancellationToken = default);
        #endregion        
    }
}
