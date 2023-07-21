using System;

namespace DataAccessExample.Requests
{
    public class SampleUpdateRequest : SampleCreateRequest
    {
        public Guid Id { get; set; }
    }
}
