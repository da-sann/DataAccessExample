using System;

namespace DataAccessExample.Interfaces.Specifications
{
    public interface IPageOptions : ISortOptions
    {
        int? Size { get; }
        int? Page { get; }
    }
}
