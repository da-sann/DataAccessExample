using DataAccessExample.Entities;

namespace DataAccessExample.Interfaces.Uow
{
    public interface ISampleEntityRepository : IRepository<SampleEntity, Guid>
    {
    }
}
