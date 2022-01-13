using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommGate.Core.Entities
{
    public class BaseEntity
    {
        [StringLength(64)]
        public string? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(64)]
        public string? LastModifiedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }
    }
}
