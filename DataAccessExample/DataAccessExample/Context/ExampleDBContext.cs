using DataAccessExample.Configurations;
using DataAccessExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessExample.Context
{
	public class ExampleDBContext : BaseDbContext
	{
		public ExampleDBContext(DbContextOptions<ExampleDBContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			DbConfigurator.Configure<ExampleDBContext>(modelBuilder);
		}

		#region DbSets
		public DbSet<SampleEntity> SampleEntities { get; set; }
		public DbSet<AnotherEntiry> AnotherEnties { get; set; }

		#endregion
	}
}
