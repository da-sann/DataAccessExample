using System;
using System.Linq.Expressions;
using DataAccessExample.Interfaces.Specifications;

namespace DataAccessExample.Specifications
{
    public abstract class BaseSpecification<TEntity> : ISpecification<TEntity> where TEntity : class
    {
        public abstract Expression<Func<TEntity, bool>> BuildCriteria();
        protected ISpecification<TEntity> True
        {
            get { return new TrueSpecification<TEntity>(); }
        }
    }
}
