using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.Entities
{

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationRole Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
    }

    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
    }

    public class ApplicationUserToken : IdentityUserToken<string>
    {
    }

    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
    }

    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole() { }
        public ApplicationRole(string name)
            : base()
        {
            this.Name = name;
        }
      
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

    }
    public class ApplicationUser : IdentityUser<string>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string? DisplayName { get; set; }
        public int? CompanyId { get; set; }
        public byte? UserType { get; set; }
        public bool? Deactivate { get; set; }
        public DateTime? DeactivateOn { get; set; }
        public int? DeactivateBy { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual Company Company { get; set; }

    }
    }
