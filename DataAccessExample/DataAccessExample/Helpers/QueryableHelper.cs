using System;
using AutoMapper.QueryableExtensions;
using DataAccessExample.Interfaces.Specifications;
using DataAccessExample.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessExample.Helpers
{
    public static class QueryableHelper
    {
        public static TResult[] ToArray<TSource, TResult>(this IQueryable<TSource> source)
        {
            return source.ProjectTo<TResult>(MapperConfig.Instance).ToArray();
        }

        public static Task<TResult[]> ToArrayAsync<TSource, TResult>(
            this IQueryable<TSource> source,
            CancellationToken cancellationToken)
        {
            return source.ProjectTo<TResult>(MapperConfig.Instance).ToArrayAsync(cancellationToken);
        }

        public static TResult Single<TSource, TResult>(this IQueryable<TSource> source)
        {
            return source.ProjectTo<TResult>(MapperConfig.Instance).SingleOrDefault();
        }

        public static Task<TResult> SingleAsync<TSource, TResult>(
            this IQueryable<TSource> source,
            CancellationToken cancellationToken)
        {
            return source.ProjectTo<TResult>(MapperConfig.Instance).SingleOrDefaultAsync(cancellationToken);
        }

        public static async Task<PagedList<TResult>> ToLookupAsync<TSource, TResult>(this IQueryable<TSource> source,
            IPagedSpecification options, CancellationToken cancellationToken) where TSource : class
            where TResult : class
        {
            var page = options.Page ?? 1;
            var size = options.Size ?? 20;

            var count = await source.CountAsync(cancellationToken);
            if (size == 0)
                size = count;
            if (count == 0)
                return new PagedList<TResult>(new TResult[0], count, page, size);

            var items = await options.OrderBy(source)
                .Skip((page - 1) * size)
                .Take(size)
                .ProjectTo<TResult>(MapperConfig.Instance)
                .ToArrayAsync(cancellationToken);
            return new PagedList<TResult>(items, count, page, size);
        }
    }
}
