using System;

namespace DataAccessExample.Entities
{
    public class SampleEntity : ArchivableEntity<Guid>
    {
        public string StringProperty { get; set; }
        public DateTime DateProperty { get; set; }
        public long AnotherProperty_Id { get; set; }

        public AnotherEntiry AnotherProperty { get; set; }
    }
}
