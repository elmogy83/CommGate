using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.Entities
{
    public class Correspondence : BaseEntity
    {
        public Correspondence()
        {
            ActionHistories = new HashSet<ActionHistory>();
            Documents = new HashSet<Document>();

        }
        [Key]
        public long Id { get; set; }
        public Guid CorrespondenceId { get; set; }
        [Required]
        public string Subject { get; set; }
        public int PurposeId { get; set; }
        public virtual Purpose Purpose { get; set; }
        public string ExternalRefNo { get; set; }
        public string PWARefNo { get; set; }
        public DateTime? SentDate { get; set; }
        public DateTime? RecivedDate { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<ActionHistory> ActionHistories { get; set; }
        public virtual ICollection<Document> Documents { get; set; }


    }
}
