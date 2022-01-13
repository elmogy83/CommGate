using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.Entities
{
    public class ActionHistory : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public long CorrespondenceId { get; set; }
        public int StatusId { get; set; }
        public DateTime ActionDate { get; set; }
        public virtual Correspondence Correspondence { get; set; }
       
    }
}
