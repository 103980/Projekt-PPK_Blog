using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace Blog.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var superAdminRoleId = "2fc79837-f508-4620-b81e-8d33a11137df";
            var adminRoleId = "75927a67-82a8-4a55-b2a6-9d531a77d57d";
            var userRoleId = "86582ceb-61d5-41d7-a9ea-849fbd8dd79b";
            //Creating all roles (User,Admin,S_Admin)
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                Name = "SuperAdmin",
                NormalizedName = "SuperAdmin",
                Id = superAdminRoleId,
                ConcurrencyStamp = superAdminRoleId

                },
                new IdentityRole()
                {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = adminRoleId,
                ConcurrencyStamp = adminRoleId

                },
                new IdentityRole()
                {
                Name = "User",
                NormalizedName = "User",
                Id = userRoleId,
                ConcurrencyStamp = userRoleId

                }

            };
            builder.Entity<IdentityRole>().HasData(roles);



            //Create Super Admin with all roles
            var superAdminId = "0e1a5577-a544-46c6-a5a4-1a96e1e72f57";
            var superAdminUser = new IdentityUser()
            {
                Id = superAdminId,
                UserName = "superadmin@blog.com",
                Email = "superadmin@blog.com",
                NormalizedEmail = "superadmin@blog.com".ToUpper(),
                NormalizedUserName = "superadmin@blog.com".ToUpper()
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "superadmin!@#");
            builder.Entity<IdentityUser>().HasData(superAdminUser);

            //Adding All rights to superAdmin
            var superAdminRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId= superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId= superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId= superAdminId
                },

            };
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);

        }

    }
}
//User:SuperAdmin: superadmin@blog.com

//Hasło: superadmin!@#

//User: User1
//Hasło: User1