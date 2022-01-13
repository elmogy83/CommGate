using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.Entities
{
    public class Company:BaseEntity
    {
        public Company()
        {
            Users = new HashSet<User>();
        }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
