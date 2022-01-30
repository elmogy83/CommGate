using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.DTOs
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]        
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }      

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

    
        public int key { get; set; }
       


    }
}
