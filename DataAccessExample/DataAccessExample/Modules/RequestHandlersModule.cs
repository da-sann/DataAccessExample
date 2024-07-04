using Autofac;
using DataAccessExample.Handlers;
using DataAccessExample.Interfaces;
using MediatR;

namespace DataAccessExample.Modules
{
	public class RequestHandlersModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);
			var handlers = ThisAssembly.GetTypes()
				.Where(t => t.IsClosedTypeOf(typeof(IRequestHandler<,>)) || t.IsClosedTypeOf(typeof(INotificationHandler<>)))
				.ToArray();
			Array.ForEach(handlers, e => builder.RegisterType(e).AsSelf().AsImplementedInterfaces());

			/*builder.Register<ServiceFactory>(ctx => {
				var c = ctx.Resolve<IComponentContext>();
				return t => c.Resolve(t);
			});*/
			builder.RegisterType<SampleDispatcher>().As<ISampleDispatcher>();
		}
	}
}
