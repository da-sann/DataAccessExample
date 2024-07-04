using Microsoft.EntityFrameworkCore;

namespace DataAccessExample.Configurations
{
    public interface IEntityTypeConfiguration
    {
        void Configure(ModelBuilder modelBuilder);
    }
}
