using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommGate.Core.Entities
{
    public class User : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string? UserName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }

        [Required]
        public string JobTitle { get; set; }
        public int? CompanyId { get; set; }
        public virtual Company? Company { get; set; }



    }
}
