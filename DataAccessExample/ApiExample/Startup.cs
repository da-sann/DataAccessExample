using Autofac;
using DataAccessExample.Filters;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.OpenApi.Models;
using System.IO.Compression;
using System.Text.Json.Serialization;

namespace ApiExample
{
	public class Startup
	{
		private readonly string[] DefaultRoutes = new[] { "/" };

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services, IWebHostEnvironment env)
		{
			services
		   .AddControllers(options =>
		   {
			   options.RespectBrowserAcceptHeader = true;
			   options.Filters.Add(typeof(HandleErrorFilter));

		   })
		   .AddJsonOptions(options =>
		   {
			   options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
		   });

			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

			services.AddHttpClient();
			services.AddMvc(options =>
			{
				options.RespectBrowserAcceptHeader = true;
			});

			services.AddCors();

			services.AddLogging(loggingBuilder =>
			{
				loggingBuilder.ClearProviders();
			});

			services.AddAntiforgery(options =>
			{
				options.SuppressXFrameOptionsHeader = true;
			});

			ConfigureCompression(services);
		}

		public void ConfigureCompression(IServiceCollection services)
		{
			services.AddResponseCompression(options =>
			{
				options.Providers.Add<GzipCompressionProvider>();
			});

			services.Configure<GzipCompressionProviderOptions>(options =>
			{
				options.Level = CompressionLevel.Fastest;
			});
		}

		public void Configure(WebApplication app, IWebHostEnvironment env)
		{
			app.UseStaticFiles();

			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "Sample Api"));

			app.UseResponseCompression();

			app.UseCors(c => c
				.SetIsOriginAllowed(_ => true)
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader());

			app.UseRouting();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.Use(async (context, next) =>
			{
				if (DefaultRoutes.Contains(context.Request.Path.Value.ToLowerInvariant()))
				{
					context.Response.Redirect("/api/index.html");
					return;
				}
				await next();
			});
			app.UseStaticFiles();
			app.UseRouting();

			app.UseResponseCompression();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
			});
			app.UseSwagger(c =>
			{
				c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
				{
					swaggerDoc.Servers = new List<OpenApiServer> {
						new OpenApiServer {
							Url = $"{httpReq.Scheme}://{httpReq.Host.Value}/"
						}
					};
				});
			});
			app.UseSwaggerUI(c =>
			{
				c.DisplayOperationId();
				c.RoutePrefix = "api";
				c.DocumentTitle = "Sample API";
			});
		}
	}
}
