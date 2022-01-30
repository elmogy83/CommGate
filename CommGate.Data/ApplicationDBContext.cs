using CommGate.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
             : base(options)
        {
        }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<ActionHistory> ActionHistories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Correspondence> Correspondences { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Purpose> Purposes { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<ApplicationRole>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<ApplicationUser>()
                .ToTable("AspNetUsers")
                .HasKey(x => x.Id);

            builder.Entity<ApplicationRole>()
                .ToTable("AspNetRoles")
                .HasKey(x => x.Id);

            builder.Entity<ApplicationUserRole>()
                .ToTable("AspNetUserRoles")
                .HasKey(x => new { x.RoleId, x.UserId });

            builder.Entity<ApplicationUserLogin>()
                .ToTable("AspNetUserLogins")
                .HasKey(x => new { x.ProviderKey, x.LoginProvider });

            builder.Entity<ApplicationUserClaim>()
                .ToTable("UserClaims");

            builder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });

        }


    }
}
