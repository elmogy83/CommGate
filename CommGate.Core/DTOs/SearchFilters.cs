using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.DTOs
{
    public class SearchFilters
    {

        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public string SortBy { get; set; }

        public string SortStyle { get; set; }


        public string Culture { get; set; }

        public bool IsEnglish { get; set; }
    }
}
