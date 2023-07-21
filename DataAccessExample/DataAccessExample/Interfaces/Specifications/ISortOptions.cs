using System;

namespace DataAccessExample.Interfaces.Specifications
{
    public interface ISortOptions
    {
        string SortBy { get; }
        byte? SortOrder { get; }
    }
}
