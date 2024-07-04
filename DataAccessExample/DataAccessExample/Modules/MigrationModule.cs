using Autofac;
using DataAccessExample.Context;
using DataAccessExample.Interfaces.Context;
using Microsoft.Extensions.Configuration;

namespace DataAccessExample.Modules
{
	public class MigrationModule : Module
	{
		public MigrationModule(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		private readonly IConfiguration _configuration;

		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);
			var key = _configuration["MigrationKey"];
			builder.Register(container => new MigrationManager(key, container.Resolve<IEnumerable<IDbContext>>())).As<IMigrationManager>();
		}
	}
}
