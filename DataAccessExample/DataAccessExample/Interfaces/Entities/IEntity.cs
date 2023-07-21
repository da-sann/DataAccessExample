using System;

namespace DataAccessExample.Interfaces.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
    public interface IEntity : IEntity<long> { }
}
