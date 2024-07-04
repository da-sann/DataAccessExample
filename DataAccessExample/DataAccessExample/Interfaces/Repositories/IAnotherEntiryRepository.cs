using DataAccessExample.Entities;

namespace DataAccessExample.Interfaces.Uow
{
    public interface IAnotherEntiryRepository : IRepository<AnotherEntiry, long>
    {
    }
}
