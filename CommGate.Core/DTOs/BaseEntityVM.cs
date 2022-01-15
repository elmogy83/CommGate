using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.DTOs
{
    public class BaseEntityVM
    {

        public int CreatedBy { get; set; }
        public string CreatedByDisplay { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }

        public string ModifiedByDisplay { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
