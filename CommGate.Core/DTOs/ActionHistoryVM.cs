using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.DTOs
{
    public class ActionHistoryVM:BaseEntityVM
    {
        
        public int Id { get; set; }
        public long CorrespondenceId { get; set; }
        public int StatusId { get; set; }
        public DateTime ActionDate { get; set; }
        public virtual CorrespondenceVM Correspondence { get; set; }
    }
}
