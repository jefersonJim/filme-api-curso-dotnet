using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Data
{
    public class UsuarioDbContext: IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        private IConfiguration _config;
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> opt, IConfiguration config) : base(opt)
        {
            _config = config;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            IdentityUser<int> admin = new IdentityUser<int>()
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 1
            };

            PasswordHasher<IdentityUser<int>> hasher = new PasswordHasher<IdentityUser<int>>();
            admin.PasswordHash = hasher.HashPassword(admin, 
                _config.GetValue<string>("AdminInfo:Password"));

            builder.Entity<IdentityUser<int>>().HasData(admin);
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>
                {
                    Id = 1,
                    Name = "admin",
                    NormalizedName = "ADMIN",

                }
            );

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>
                {
                    Id = 2,
                    Name = "regular",
                    NormalizedName = "REGULAR",

                }
            );

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = 1, UserId = 1}
            );
        }
    }
}
