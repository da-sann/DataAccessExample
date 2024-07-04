using FluentValidation;
using FluentValidation.Results;
using System.Text;

namespace ApiExample.Validation
{
	public class SampleValidationException : ValidationException
	{
		private static string _message = "Ошибка валидации: ";
		public SampleValidationException(string message) : base(message) { }

		public SampleValidationException(IEnumerable<ValidationFailure> errors) : base(CreateMessage(errors), errors) { }

		private static string CreateMessage(IEnumerable<ValidationFailure> errors)
		{
			var builder = new StringBuilder();
			builder.AppendLine(_message);
			foreach (var err in errors)
			{
				var name = string.IsNullOrEmpty(err.PropertyName) ? "--" : err.PropertyName;
				builder.AppendLine(string.Format("{0} : {1}", name, err.ErrorMessage));
			}
			return builder.ToString();
		}
	}
}
