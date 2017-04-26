using System.Collections.Generic;

namespace SampleAspCore.Helpers
{
    public class Pager<T> where T : class
    {
        public string FilterKey { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public string PageSummary { get; set; }

        public IEnumerable<T> ResultSet { get; set; }
    }
}
