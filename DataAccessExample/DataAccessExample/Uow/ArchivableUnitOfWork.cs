
using System;
using System.Linq.Expressions;
using DataAccessExample.Interfaces.Context;
using DataAccessExample.Interfaces.Entities;
using DataAccessExample.Interfaces.Uow;

namespace DataAccessExample.Uow
{
    public abstract class ArchivableUnitOfWork<TEntity, TKey> : UnitOfWorkBase<TEntity, TKey>,
        IArchivableUnitOfWork<TEntity, TKey> where TEntity : class, IArchivableEntity<TKey>
    {
        public ArchivableUnitOfWork(IDbContext context) : base(context) { }

        public override void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            base.Update(entity);
        }

        public void Delete(TKey id, Action<TEntity> func, params Expression<Func<TEntity, dynamic>>[] propertyToUpdate)
        {
            var entity = base.Update(id, func, propertyToUpdate);
            entity.IsDeleted = true;
            base.Update(entity);
        }
    }
}
