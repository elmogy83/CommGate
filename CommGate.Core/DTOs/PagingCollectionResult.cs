using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.DTOs
{
    public class PagingCollectionResult<T> where T : class
    {
        public int TotalRecords { set; get; }
        public int PageSize { set; get; }
        public int PageIndex { set; get; }
        public int PagesCount => PageSize <= 0 ? 0 : (int)Math.Ceiling(Convert.ToDecimal((decimal)TotalRecords / PageSize));
        public string SortBy { get; set; }

        public string SortStyle { get; set; }
        public List<T> Items { set; get; }
    }
}
