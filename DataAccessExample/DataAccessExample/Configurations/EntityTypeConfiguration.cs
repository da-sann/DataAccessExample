using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccessExample.Configurations
{
	public abstract class EntityTypeConfiguration<TEntity> : IEntityTypeConfiguration, IEntityTypeConfiguration<TEntity> where TEntity : class
	{
		void IEntityTypeConfiguration.Configure(ModelBuilder modelBuilder)
		{
			Configure(modelBuilder.Entity<TEntity>());
		}

		protected void ConfigurePrecision<TValue>(EntityTypeBuilder<TEntity> builder, string columnType)
		{
			var prop = typeof(TEntity).GetProperties().Where(a => a.CanRead && a.CanWrite && a.PropertyType == typeof(TValue)).ToList();
			foreach (var p in prop)
				builder.Property(p.Name).HasColumnType(columnType);
		}
		public abstract void Configure(EntityTypeBuilder<TEntity> builder);
	}
}
