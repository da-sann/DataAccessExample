using System;
using DataAccessExample.Interfaces.Entities;

namespace DataAccessExample.Entities
{
    public abstract class ArchivableEntity<T> : BaseEntity<T>, IArchivableEntity<T>
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
