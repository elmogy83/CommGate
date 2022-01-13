using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.Entities
{
    public class Purpose : BaseEntity
    {
        public Purpose()
        {
            Correspondences = new HashSet<Correspondence>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string TitleEn { get; set; }
        [Required]
        public string TitleAr { get; set; }
        public virtual ICollection<Correspondence> Correspondences { get; set; }

    }
}
