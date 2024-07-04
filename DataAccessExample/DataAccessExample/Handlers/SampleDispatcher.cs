using DataAccessExample.Interfaces;
using MediatR;

namespace DataAccessExample.Handlers
{
	public class SampleDispatcher : Mediator, ISampleDispatcher
	{
		public SampleDispatcher(IServiceProvider serviceProvider) : base(serviceProvider) { }
	}
}
