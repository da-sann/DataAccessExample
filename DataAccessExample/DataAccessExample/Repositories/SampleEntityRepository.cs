using System;
using DataAccessExample.Entities;
using DataAccessExample.Interfaces.Context;
using DataAccessExample.Interfaces.Uow;

namespace DataAccessExample.Uow
{
    public class SampleEntityRepository : ArchivableRepository<SampleEntity, Guid>, ISampleEntityRepository
    {
        public SampleEntityRepository(IDbContext context) : base(context) { }
    }
}
