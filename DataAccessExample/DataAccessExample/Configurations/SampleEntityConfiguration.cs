using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DataAccessExample.Entities;

namespace DataAccessExample.Configurations
{
	public class SampleEntityConfiguration : EntityTypeConfiguration<SampleEntity>
	{
		public override void Configure(EntityTypeBuilder<SampleEntity> builder)
		{
			builder.HasOne(m => m.AnotherProperty).WithMany(m => m.SampleEntities).HasForeignKey(m => m.AnotherProperty_Id).IsRequired().OnDelete(DeleteBehavior.Restrict);
		}
	}
}
