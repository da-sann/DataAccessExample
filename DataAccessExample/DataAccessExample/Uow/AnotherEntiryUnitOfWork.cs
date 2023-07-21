using System;
using DataAccessExample.Entities;
using DataAccessExample.Interfaces.Context;

namespace DataAccessExample.Uow
{
    public class AnotherEntiryUnitOfWork : UnitOfWorkBase<AnotherEntiry, long>
    {
        public AnotherEntiryUnitOfWork(IDbContext context) : base(context) { }
    }
}
