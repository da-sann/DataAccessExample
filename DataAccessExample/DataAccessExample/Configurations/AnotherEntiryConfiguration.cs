using DataAccessExample.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccessExample.Configurations
{
	public class AnotherEntiryConfiguration : EntityTypeConfiguration<AnotherEntiry>
	{
		public override void Configure(EntityTypeBuilder<AnotherEntiry> builder)
		{
			builder.HasMany(m => m.SampleEntities).WithOne(m => m.AnotherProperty).HasForeignKey(m => m.AnotherProperty_Id).IsRequired().OnDelete(DeleteBehavior.Restrict);
		}
	}
}
