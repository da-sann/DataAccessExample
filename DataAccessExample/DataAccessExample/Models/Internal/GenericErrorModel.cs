﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace DataAccessExample.Models.Internal
{
	public class GenericErrorModel : ErrorModel
	{
		#region .ctor
		public GenericErrorModel() { }
		public GenericErrorModel(ExceptionContext context, bool showStackTrace)
		{
			Code = context.HttpContext.TraceIdentifier;
			Init(context.Exception, showStackTrace);
		}
		public GenericErrorModel(Exception ex, bool showStackTrace)
		{
			Init(ex, showStackTrace);
		}
		#endregion

		private void Init(Exception error, bool showStackTrace)
		{
			Message = error.Message;
			if (showStackTrace)
				ParseStackTrace(error);
			if (error.InnerException != null)
				InnerException = new GenericErrorModel(error.InnerException, showStackTrace);
		}

		private void ParseStackTrace(Exception exception)
		{
			if (exception.StackTrace != null)
				StackTrace = exception.StackTrace.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
			else
				StackTrace = new[] { exception.Message }; 
		}
		public GenericErrorModel InnerException { get; set; }
		public string[] StackTrace { get; set; }
	}
}
