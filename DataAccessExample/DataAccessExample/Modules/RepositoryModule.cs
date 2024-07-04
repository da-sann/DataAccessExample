using Autofac;

namespace DataAccessExample.Modules
{
	public class RepositoryModule : Module
	{
		private const string RepositoryPostfix = "Repository";
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);
			builder.RegisterAssemblyTypes(ThisAssembly)
				.Where(a => !a.IsAbstract && a.Name.EndsWith(RepositoryPostfix))
				.AsImplementedInterfaces();
		}
	}
}
