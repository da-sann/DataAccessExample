using DataAccessExample.Helpers;
using DataAccessExample.Interfaces.Specifications;
using System;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessExample.Specifications
{
    public class TransitionSpecification<TFrom, TTo> : ISpecification<TTo>
       where TTo : class
       where TFrom : class
    {
        public TransitionSpecification(ISpecification<TFrom> criteria, Expression<Func<TTo, TFrom>> selector)
        {
            _source = criteria;
            _selector = selector;
        }
        private readonly ISpecification<TFrom> _source;
        private readonly Expression<Func<TTo, TFrom>> _selector;

        public Expression<Func<TTo, bool>> BuildCriteria()
        {
            return _source.BuildCriteria().Convert(_selector);
        }
    }
}
