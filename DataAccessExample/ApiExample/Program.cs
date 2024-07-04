using ApiExample;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DataAccessExample.Modules;
using DataAccessExample.Profiles;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services, builder.Environment);

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Information);
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.WebHost.UseUrls("http://+:5000");

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());


builder.Host.ConfigureContainer<ContainerBuilder>(b =>
{
	b.RegisterModule<DBContextModule>();
	b.RegisterModule<RepositoryModule>();
	b.RegisterModule<RequestHandlersModule>();
	b.RegisterModule(new MigrationModule(builder.Configuration));
	b.RegisterModule(new AutoMapperModule(cfg =>
	{
		cfg.AddProfile<EntityToModelProfile>();
	}));
});

var app = builder.Build();

startup.Configure(app, builder.Environment);

app.Run();
