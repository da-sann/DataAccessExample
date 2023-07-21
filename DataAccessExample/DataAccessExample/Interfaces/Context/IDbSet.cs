using System;
using System.Collections;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccessExample.Interfaces.Context
{
    public interface IDbSet<TEntity> : IQueryable<TEntity>, IEnumerable<TEntity>, IEnumerable, IQueryable
         where TEntity : class
    {
        EntityEntry Attach(TEntity entity);
        TEntity Find(object id);
        ValueTask<TEntity> FindAsync(object id, CancellationToken cancellationToken);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
    }
}
