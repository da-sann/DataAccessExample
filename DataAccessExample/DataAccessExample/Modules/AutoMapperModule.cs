using Autofac;
using AutoMapper;
using DataAccessExample.Helpers;

namespace DataAccessExample.Modules
{
	public class AutoMapperModule : Module
	{
		public AutoMapperModule(Action<IMapperConfigurationExpression> setup)
		{
			_setup = setup;
		}
		private readonly Action<IMapperConfigurationExpression> _setup;

		protected override void Load(ContainerBuilder builder)
		{
			var config = new MapperConfiguration(_setup);
			MapperConfig.Initialize(config);
			builder.RegisterInstance(config).As<IConfigurationProvider>();
			builder.RegisterType<Mapper>().As<IMapper>();
		}
	}
}
