using ApiExample.Validation.Errors;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ApiExample.Validation
{
	public class ValidationResultModel : ErrorModel
	{
		public List<ValidationError> Errors { get; }
		public ValidationResultModel() : this((ModelStateDictionary)null) { }

		public ValidationResultModel(SampleValidationException exception)
		{
			Message = exception.Message;
			if (exception.Errors != null)
				Errors = exception.Errors
					.Select(a => new ValidationError(a.PropertyName, a.ErrorMessage)).ToList();
		}

		public ValidationResultModel(ModelStateDictionary modelState)
		{
			Message = @"Ошибка валидации";
			if (modelState != null)
			{
				Errors = new List<ValidationError>();
				modelState.Keys.ToList().ForEach(key => {
					var messages = modelState[key].Errors.ToList().Select(x => {
						var message = x.ErrorMessage;
						if (string.IsNullOrWhiteSpace(message))
							if (x.Exception is Newtonsoft.Json.JsonException)
								message = $"The data in {key} field is of incorrect format";
							else
								message = x.Exception.Message;
						return message;
					});
					if (messages.Count() == 0 && modelState[key].ValidationState == ModelValidationState.Unvalidated)
						messages = new string[] { $"The data in {key} field is of incorrect format" };
					messages.Distinct().ToList().ForEach(m => Errors.Add(new ValidationError(key, m)));
				});
			}
		}
	}
}
