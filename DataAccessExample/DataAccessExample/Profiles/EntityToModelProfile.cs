using AutoMapper;
using DataAccessExample.Entities;
using DataAccessExample.Models;

namespace DataAccessExample.Profiles
{
	public class EntityToModelProfile : Profile
	{
		public EntityToModelProfile()
		{
			CreateMap<SampleEntity, SampleModel>();
			CreateMap<AnotherEntiry, AnotherModel>();
		}
	}
}
