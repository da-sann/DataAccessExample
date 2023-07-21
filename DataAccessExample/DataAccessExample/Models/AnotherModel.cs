using System;

namespace DataAccessExample.Models
{
    public class AnotherModel : BaseModel<long>
    {
        public string StringProperty { get; set; }
        public string DateProperty { get; set; }
    }
}
