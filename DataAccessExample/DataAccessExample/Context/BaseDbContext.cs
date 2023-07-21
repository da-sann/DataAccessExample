using System;
using DataAccessExample.Interfaces.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace DataAccessExample.Context
{
    public abstract class BaseDbContext : DbContext, IDbContext
    {
        protected BaseDbContext(DbContextOptions options) : base(options)
        {
        }
        private static readonly Object obj = new Object();

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            lock (obj)
            {
                return new DbQuery<TEntity>(Set<TEntity>());
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            lock (obj)
            {
                base.OnConfiguring(optionsBuilder);
            }
        }

        private bool _isDisposed;

        public string ContextName => GetType().Name;

        public override void Dispose()
        {
            if (_isDisposed) return;
            base.Dispose();
            _isDisposed = true;
        }

        private void DetachAll()
        {
            var entires = ChangeTracker.Entries().ToArray();
            foreach (var entry in entires)
            {
                if (entry.Entity != null)
                    entry.State = EntityState.Detached;
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            DetachAll();
            return result;
        }

        public override int SaveChanges()
        {
            var result = base.SaveChanges();
            DetachAll();
            return result;
        }

        public int SaveChangesWithoutDetach()
        {
            return base.SaveChanges();
        }

        public Task<int> SaveChangesWithoutDetachAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public Task MigrateAsync(CancellationToken cancellationToken)
        {
            return Database.MigrateAsync(cancellationToken);
        }

        public async Task<string[]> GetMigrationsAsync(CancellationToken cancellationToken)
        {
            var migrations = await Database.GetPendingMigrationsAsync(cancellationToken);
            return migrations.ToArray();
        }
    }
}
