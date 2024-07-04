using System;

namespace DataAccessExample.Entities
{
    public class AnotherEntiry : BaseEntity<long>
    {
        public string StringProperty { get; set; }
        public DateTime DateProperty { get; set; }

        public ICollection<SampleEntity> SampleEntities { get; set; }
    }
}
