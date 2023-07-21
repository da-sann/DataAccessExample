using System;
using System.Linq.Expressions;
using DataAccessExample.Interfaces.Specifications;

namespace DataAccessExample.Specifications
{
    public class TrueSpecification<TEntity> : ISpecification<TEntity> where TEntity : class
    {
        public Expression<Func<TEntity, bool>> BuildCriteria()
        {
            return a => true;
        }
    }
}
