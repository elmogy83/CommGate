using System.Collections.Generic;

namespace CommGate.Core.Specifications
{
    public sealed class SearchModelResult<T>
    {
        public IEnumerable<T> SearchResult { get; set; }

        public int SearchTotalCount { get; set; }
    }

}
