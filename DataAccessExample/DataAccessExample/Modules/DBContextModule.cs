﻿using DataAccessExample.Configurations;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Autofac;
using DataAccessExample.Context;

namespace DataAccessExample.Modules
{
	public class DBContextModule : Module, IDesignTimeDbContextFactory<ExampleDBContext>
	{
		protected static IConfiguration GetConfiguration()
		{
			return new ConfigurationBuilder()
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json")
			.Build();
		}
		private static IContainer _container;
		public ExampleDBContext CreateDbContext(string[] args)
		{
			var builder = new ContainerBuilder();
			Load(builder);
			builder.RegisterInstance(_configuration);
			builder.RegisterType<ExampleDBContext>();
			_container = builder.Build();
			return _container.Resolve<ExampleDBContext>();
		}

		public DBContextModule() : this(GetConfiguration()) { }
		public DBContextModule(IConfiguration configuration)
		{
			_configuration = configuration;
			_contextName = typeof(ExampleDBContext).Name;
			_optionsBuilder = new DbContextOptionsBuilder<ExampleDBContext>();
			_optionsBuilder.UseSqlServer(_configuration.GetConnectionString(_contextName), a => {
				a.CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
				a.EnableRetryOnFailure(3);
				a.MigrationsAssembly(ThisAssembly.FullName);
				a.MigrationsHistoryTable(String.Format("__{0}Migrations", _contextName));
			});
		}
		private readonly IConfiguration _configuration;
		protected IConfiguration Configuration
		{
			get
			{
				return _configuration;
			}
		}
		private readonly string _contextName;
		private readonly DbContextOptionsBuilder<ExampleDBContext> _optionsBuilder;

		protected override void Load(ContainerBuilder builder)
		{
			DbConfigurator.Register(ThisAssembly);
			builder.RegisterInstance(_optionsBuilder.Options);
			RegisterContext(builder);
			base.Load(builder);
		}

		protected virtual void RegisterContext(ContainerBuilder builder, params Type[] constructorArgs)
		{
			var registrator = builder.RegisterType<ExampleDBContext>().AsImplementedInterfaces().InstancePerLifetimeScope();
			if (constructorArgs.Length > 0)
				registrator.UsingConstructor(constructorArgs);
		}
		protected override System.Reflection.Assembly ThisAssembly => GetType().Assembly;
	}
}
