using System;
using System.Linq.Expressions;

namespace DataAccessExample.Interfaces.Specifications
{
    public interface ISpecification<TEntity> where TEntity : class
    {
        Expression<Func<TEntity, bool>> BuildCriteria();
    }
}
