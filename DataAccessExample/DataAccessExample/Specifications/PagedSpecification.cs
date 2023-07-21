using DataAccessExample.Interfaces.Specifications;
using System;

namespace DataAccessExample.Specifications
{
    public abstract class PagedSpecification<TEntity> : OrderSpecification<TEntity>, IPagedSpecification
       where TEntity : class
    {
        public const int DefaultPageSize = 10;
        public PagedSpecification()
        {
            Size = DefaultPageSize;
            Page = 1;
        }

        public int? Page { get; set; }
        public int? Size { get; set; }

    }
}
