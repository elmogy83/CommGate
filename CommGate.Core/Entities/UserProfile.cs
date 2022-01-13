using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommGate.Core.Entities
{
    public class UserProfile : BaseEntity
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(50)]
        public string? UserName { get; set; }


        [MaxLength(50)]
        public string Email { get; set; }

        public string FullName { get; set; }
        public string ArabicFullName { get; set; }

        
        public string JobTitle { get; set; }
        public string ArabicJobTitle { get; set; }

      
    }
}
