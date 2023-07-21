using System;

namespace DataAccessExample.Models
{
    public class BaseModel<T>
    {
        public T Id { get; set; }
    }

    public class BaseModel : BaseModel<long> { }

    public class BaseModelGuid : BaseModel<Guid> { }
}
