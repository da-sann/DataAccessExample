using System;

namespace DataAccessExample.Interfaces.Context
{
    public interface IDbContext : IDisposable
    {
        Task MigrateAsync(CancellationToken cancellationToken);
        string ContextName { get; }
        Task<string[]> GetMigrationsAsync(CancellationToken cancellationToken);
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        int SaveChanges();
    }
}
