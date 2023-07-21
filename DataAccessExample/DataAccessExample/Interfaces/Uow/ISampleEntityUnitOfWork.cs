using DataAccessExample.Entities;

namespace DataAccessExample.Interfaces.Uow
{
    public interface ISampleEntityUnitOfWork : IUnitOfWork<SampleEntity, Guid>
    {
    }
}
