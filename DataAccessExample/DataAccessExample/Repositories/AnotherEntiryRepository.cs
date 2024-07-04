using System;
using DataAccessExample.Entities;
using DataAccessExample.Interfaces.Context;
using DataAccessExample.Interfaces.Uow;

namespace DataAccessExample.Uow
{
    public class AnotherEntiryRepository : RepositoryBase<AnotherEntiry, long>, IAnotherEntiryRepository
    {
        public AnotherEntiryRepository(IDbContext context) : base(context) { }
    }
}
