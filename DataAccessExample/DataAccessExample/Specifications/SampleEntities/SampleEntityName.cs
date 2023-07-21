using System;
using System.Linq.Expressions;
using DataAccessExample.Entities;

namespace DataAccessExample.Specifications.SampleEntities
{
    public class SampleEntityByName : BaseSpecification<SampleEntity>
    {
        public SampleEntityByName(string name)
        {
            _name = name.Trim().ToLower();
        }

        private readonly string _name;

        public override Expression<Func<SampleEntity, bool>> BuildCriteria()
        {
            return s => s.StringProperty.ToLower().Contains(_name);
        }
    }
}
