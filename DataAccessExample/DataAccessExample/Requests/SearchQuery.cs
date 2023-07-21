using DataAccessExample.Models;

namespace DataAccessExample.Requests
{
    public class SearchQuery : PagedQuery<SampleModel>
    {
        public SearchQuery()
        {
            Page = 1;
            Size = 20;
            SortOrder = 1;
            SortBy = "CreatedOn";
        }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool ActiveOnly { get; set; }
    }
}
