using System;
using System.Linq.Expressions;
using DataAccessExample.Interfaces.Entities;
using DataAccessExample.Interfaces.Specifications;
using DataAccessExample.Specifications;

namespace DataAccessExample.Helpers
{
    public static class SpecificationHelpers
    {
        public static ISpecification<TEntity> And<TEntity>(this ISpecification<TEntity> from, ISpecification<TEntity> to) where TEntity : class
        {
            if (to != null)
                return new CombinedSpecification<TEntity>(from, to);
            else
                return from;
        }

        public static ISpecification<TEntity> Or<TEntity>(this ISpecification<TEntity> left, ISpecification<TEntity> right) where TEntity : class
        {
            return new OtherwiseSpecification<TEntity>(left, right);
        }

        public static ISpecification<TResult> Convert<TEntity, TResult>(this ISpecification<TEntity> from, Expression<Func<TResult, TEntity>> selector)
            where TEntity : class, IEntity
             where TResult : class, IEntity
        {
            return new TransitionSpecification<TEntity, TResult>(from, selector);
        }
    }
}
