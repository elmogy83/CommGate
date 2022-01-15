using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.DTOs
{
    public class PurposeVM : BaseEntityVM
    {
        public PurposeVM()
        {
            Correspondences = new HashSet<CorrespondenceVM>();
        }
      
        public int Id { get; set; }
        [Required]
        public string TitleEn { get; set; }
        [Required]
        public string TitleAr { get; set; }
        public virtual ICollection<CorrespondenceVM> Correspondences { get; set; }

    }
}
