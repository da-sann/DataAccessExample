using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Extensions.Hosting;
using DataAccessExample.Models.Internal;

namespace DataAccessExample.Filters
{
	public class HandleErrorFilter : ExceptionFilterAttribute
	{
		/// <summary>
		/// Ctor
		/// </summary>
		/// <param name="logger">Логгер</param>
		/// <param name="environment">Информация об окружении</param>
		public HandleErrorFilter(ILogger<HandleErrorFilter> logger, IHostEnvironment environment)
		{
			_isDevelopment = environment.IsDevelopment();
			_logger = logger;
		}
		private readonly ILogger _logger;
		private readonly bool _isDevelopment;
		private const string UnhandledException = "An unhandled exception has occurred while executing the request {0}. {1}";

		public override void OnException(ExceptionContext context)
		{
			base.OnException(context);
			switch (context.Exception)
			{
				default:
					SetExceptionResult(context);
					break;
			}
			context.ExceptionHandled = true;
		}

		public override async Task OnExceptionAsync(ExceptionContext context)
		{
			await base.OnExceptionAsync(context);

			switch (context.Exception)
			{
				default:
					SetExceptionResult(context);
					break;
			}
			context.ExceptionHandled = true;
		}

		private void SetExceptionResult(ExceptionContext context)
		{
			_logger.LogError(string.Format(UnhandledException, context.HttpContext.TraceIdentifier, context.Exception));
			var result = new ObjectResult(new GenericErrorModel(context, _isDevelopment));
			result.StatusCode = (int)HttpStatusCode.InternalServerError;
			context.Result = result;
		}
	}
}
