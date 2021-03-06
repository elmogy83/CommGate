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
        [MaxLength(256)]
        public string NameEn { get; set; }
        [Required]
        [MaxLength(256)]
        public string NameAr { get; set; }

        public virtual ICollection<Correspondence> Correspondences { get; set; }


    }
}
