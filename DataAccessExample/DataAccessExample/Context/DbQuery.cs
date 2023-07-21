using System;
using System.Collections;
using System.Linq.Expressions;
using DataAccessExample.Interfaces.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace DataAccessExample.Context
{
    public class DbQuery<TEntity> : IDbSet<TEntity> where TEntity : class
    {
        public DbQuery(DbSet<TEntity> set)
        {
            _set = set;
            _query = set;
        }
        private readonly DbSet<TEntity> _set;

        public EntityEntry Attach(TEntity entity)
        {
            return _set.Attach(entity);
        }

        public void Add(TEntity entity)
        {
            _set.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _set.Remove(entity);
        }

        public ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _set.AddAsync(entity, cancellationToken);
        }

        public TEntity Find(object id)
        {
            return _set.Find(id);
        }

        public ValueTask<TEntity> FindAsync(object id, CancellationToken cancellationToken)
        {
            return _set.FindAsync(new[] { id }, cancellationToken);
        }

        #region IQueryable
        private readonly IQueryable<TEntity> _query;

        public Type ElementType => _query.ElementType;

        public Expression Expression => _query.Expression;

        public IQueryProvider Provider => _query.Provider;

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _query.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
