using System;
using System.Linq.Expressions;
using DataAccessExample.Helpers;
using DataAccessExample.Interfaces.Specifications;

namespace DataAccessExample.Specifications
{
    public class CombinedSpecification<TEntity> : ISpecification<TEntity> where TEntity : class
    {
        public CombinedSpecification(ISpecification<TEntity> from, ISpecification<TEntity> to)
        {
            _from = from;
            _to = to;
        }
        private readonly ISpecification<TEntity> _from;
        private readonly ISpecification<TEntity> _to;

        public Expression<Func<TEntity, bool>> BuildCriteria()
        {
            return _from.BuildCriteria().And(_to.BuildCriteria());
        }
    }
}
