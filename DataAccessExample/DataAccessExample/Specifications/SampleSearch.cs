using System;
using System.Linq.Expressions;
using DataAccessExample.Entities;
using DataAccessExample.Helpers;
using DataAccessExample.Specifications.SampleEntities;

namespace DataAccessExample.Specifications
{
    public class SampleSearch : PagedSpecification<SampleEntity>
    {
        public string Name { get; set; }
        public DateTime? DateProperty { get; set; }

        public override Expression<Func<SampleEntity, bool>> BuildCriteria()
        {
            var criteria = True;
            if (!string.IsNullOrEmpty(Name))
                criteria = criteria.And(new SampleEntityByName(Name));
            if (DateProperty.HasValue)
                criteria = criteria.And(new SampleEntityByDate(DateProperty.Value));
 
            return criteria.BuildCriteria();
        }
    }
}
