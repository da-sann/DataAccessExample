using System;

namespace DataAccessExample.Interfaces.Entities
{
    public interface IArchivableEntity<TKey> : IAuditableEntity<TKey>
    {
        bool IsDeleted { get; set; }
    }
}
