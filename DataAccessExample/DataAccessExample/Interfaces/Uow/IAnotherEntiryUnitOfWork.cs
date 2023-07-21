using DataAccessExample.Entities;

namespace DataAccessExample.Interfaces.Uow
{
    public interface IAnotherEntiryUnitOfWork : IUnitOfWork<AnotherEntiry, long>
    {
    }
}
