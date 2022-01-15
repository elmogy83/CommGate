using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.DTOs
{
    public class CorrespondenceVM : BaseEntityVM
    {
        public CorrespondenceVM()
        {
            ActionHistories = new HashSet<ActionHistoryVM>();
            Documents = new HashSet<DocumentVM>();
        }
        
        public long Id { get; set; }
        public Guid CorrespondenceId { get; set; }
        [Required]
        public string Subject { get; set; }
        public int PurposeId { get; set; }
        public virtual PurposeVM Purpose { get; set; }
        public string ExternalRefNo { get; set; }
        public string PWARefNo { get; set; }
        public DateTime? SentDate { get; set; }      
        public int StatusId { get; set; }
        public virtual StatusVM Status { get; set; }
        public int DepartmentId { get; set; }
        public virtual DepartmentVM Department { get; set; }
        public virtual ICollection<ActionHistoryVM> ActionHistories { get; set; }
        public virtual ICollection<DocumentVM> Documents { get; set; }
        public string RecivedDateDisplay { get { return CreatedOn.ToString(SiteSettings.DateDisplayFormat); } }


    }
}
