using DataAccessExample.Entities;
using System.Linq.Expressions;

namespace DataAccessExample.Specifications.SampleEntities
{
    public class SampleEntityByDate : BaseSpecification<SampleEntity>
    {
        public SampleEntityByDate(DateTime date)
        {
            _date = date;
        }

        private readonly DateTime _date;

        public override Expression<Func<SampleEntity, bool>> BuildCriteria()
        {
            return s => s.DateProperty <= _date;
        }
    }
}
