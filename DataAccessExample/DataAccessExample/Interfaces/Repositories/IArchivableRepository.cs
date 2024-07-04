using System;
using System.Linq.Expressions;
using DataAccessExample.Interfaces.Entities;

namespace DataAccessExample.Interfaces.Uow
{
    public interface IArchivableRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IArchivableEntity<TKey>
    {
        void Delete(TKey id, Action<TEntity> func, params Expression<Func<TEntity, dynamic>>[] propertyToUpdate);
    }
}
