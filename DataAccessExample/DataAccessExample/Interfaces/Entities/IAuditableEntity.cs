using System;

namespace DataAccessExample.Interfaces.Entities
{
    public interface IAuditableEntity<TKey> : IEntity<TKey>
    {
        DateTime CreatedOn { get; set; }
        DateTime? UpdatedOn { get; set; }
    }
}
