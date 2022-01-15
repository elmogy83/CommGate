using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.DTOs
{
    public class DocumentVM:BaseEntityVM
    {
       
        public long Id { get; set; }
        public string Name { get; set; }
        public string DocumentTitle { get; set; }
        public long Size { get; set; }
        public byte TypeId { get; set; }
        public string DocumentNumber { get; set; }
        public long CorrespondenceId { get; set; }
        public virtual CorrespondenceVM Correspondence { get; set; }

    }
}
