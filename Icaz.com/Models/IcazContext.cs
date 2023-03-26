using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Icaz.com.Models
{
    public class IcazContext:IdentityDbContext<IdentityUser>
    {
        public IcazContext(DbContextOptions<IcazContext>options):base(options)
        {

        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Makale> Makales { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Konu> Konus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
