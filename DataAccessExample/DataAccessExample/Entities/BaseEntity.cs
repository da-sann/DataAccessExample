using System;
using DataAccessExample.Interfaces.Entities;

namespace DataAccessExample.Entities
{
    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
        public virtual Type EntityType
        {
            get { return GetType(); }
        }
    }
}
