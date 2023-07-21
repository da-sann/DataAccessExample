using System;

namespace DataAccessExample.Interfaces.Specifications
{
    public interface ISortSpecification : ISortOptions
    {
        IQueryable<T> OrderBy<T>(IQueryable<T> source) where T : class;
        IQueryable OrderBy(IQueryable source);
    }
}
