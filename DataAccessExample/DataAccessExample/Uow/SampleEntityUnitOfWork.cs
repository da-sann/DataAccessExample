using System;
using DataAccessExample.Entities;
using DataAccessExample.Interfaces.Context;

namespace DataAccessExample.Uow
{
    public class SampleEntityUnitOfWork : ArchivableUnitOfWork<SampleEntity, Guid>
    {
        public SampleEntityUnitOfWork(IDbContext context) : base(context) { }
    }
}
