using System;
using System.Linq.Expressions;

namespace DataAccessExample.Helpers
{
    internal class ParameterTypeVisitor<TFrom, TTo> : ExpressionVisitor
    {
        public ParameterTypeVisitor(Expression<Func<TTo, TFrom>> selector)
        {
            _selector = selector;
        }
        private readonly Expression<Func<TTo, TFrom>> _selector;

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node.Type == typeof(TFrom))
                return Visit(_selector.Body);
            return base.VisitParameter(node);
        }
    }
}
