using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.Entities
{
    public class Department:BaseEntity
    {
        public Department()
        {
            Correspondences=new HashSet<Correspondence>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string DepartmentNameEn { get; set; }
        [Required]
        public string DepartmentNameAr { get; set; }

        public virtual ICollection<Correspondence> Correspondences { get; set; }


    }
}
