using DataAccessExample.Helpers;
using DataAccessExample.Interfaces.Specifications;
using System;
using System.Linq.Expressions;

namespace DataAccessExample.Specifications
{
    public abstract class OrderSpecification<TEntity> : BaseSpecification<TEntity>, ISortSpecification where TEntity : class
    {

        protected string DefaultSortBy = "Id";
        public string SortBy { get; set; }
        public byte? SortOrder { get; set; }

        public void SetSortBy(Expression<Func<TEntity, dynamic>> selector)
        {
            var memberEpression = selector.Body as MemberExpression;
            SortBy = memberEpression.Member.Name;
        }

        public IQueryable<T> OrderBy<T>(IQueryable<T> source) where T : class
        {
            return source.Provider.CreateQuery<T>(OrderyByExpression(source));
        }

        public IQueryable OrderBy(IQueryable source)
        {
            return source.Provider.CreateQuery(OrderyByExpression(source));
        }

        private Expression OrderyByExpression(IQueryable source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (String.IsNullOrWhiteSpace(SortBy))
                SortBy = DefaultSortBy;

            var param = Expression.Parameter(source.ElementType, "p");
            var body = param.GetProperty(SortBy);
            var orderByExp = Expression.Lambda(body, param);
            var typeArguments = new Type[] { source.ElementType, body.Type };
            return Expression.Call(typeof(Queryable),
                !SortOrder.HasValue || SortOrder == 1 ? "OrderBy" : "OrderByDescending",
                typeArguments, source.Expression, Expression.Quote(orderByExp));
        }
    }
}
