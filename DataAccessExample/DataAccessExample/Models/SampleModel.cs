using DataAccessExample.Entities;
using System;

namespace DataAccessExample.Models
{
    public class SampleModel : BaseModelGuid
    {
        public string StringProperty { get; set; }
        public string DateProperty { get; set; }
        public AnotherModel AnotherProperty { get; set; }
    }
}
