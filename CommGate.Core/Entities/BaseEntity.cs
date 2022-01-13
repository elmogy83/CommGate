using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommGate.Core.Entities
{
    public class BaseEntity
    {        
        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }
       
        public int LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }
    }
}
