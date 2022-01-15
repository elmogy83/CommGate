using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.DTOs
{
    public class StatusVM:BaseEntityVM
    {
     
     
        public int Id { get; set; }
        [Required]
        public string TitleEn { get; set; }
        [Required]
        public string TitleAr { get; set; }
    }
}
