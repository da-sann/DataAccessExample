using DataAccessExample.Interfaces;
using DataAccessExample.Models;
using System;

namespace DataAccessExample.Requests
{
    public class PagedQuery<TResponse> : IRequest<PagedList<TResponse>>
    {
        public string SortBy { get; set; }
        public byte? SortOrder { get; set; }

        public int? Page { get; set; }
        public int? Size { get; set; }
    }
}
