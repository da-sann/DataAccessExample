using System;
using System.Linq.Expressions;
using DataAccessExample.Helpers;
using DataAccessExample.Interfaces.Specifications;

namespace DataAccessExample.Specifications
{
    public class OtherwiseSpecification<TEntity> : ISpecification<TEntity> where TEntity : class
    {
        public OtherwiseSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
        {
            _left = left;
            _right = right;
        }
        private readonly ISpecification<TEntity> _left;
        private readonly ISpecification<TEntity> _right;

        public Expression<Func<TEntity, bool>> BuildCriteria()
        {
            return _left.BuildCriteria().Or(_right.BuildCriteria());
        }
    }
}
