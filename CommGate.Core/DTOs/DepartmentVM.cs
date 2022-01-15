using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.DTOs
{
    public class DepartmentVM:BaseEntityVM
    {
        public DepartmentVM()
        {
            Correspondences=new HashSet<CorrespondenceVM>();
        }
      
        public int Id { get; set; }
        [Required]
        public string NameEn { get; set; }
        [Required]
        public string NameAr { get; set; }

        public virtual ICollection<CorrespondenceVM> Correspondences { get; set; }


    }
}
