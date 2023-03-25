using Microsoft.EntityFrameworkCore;

namespace Icaz.com.Models
{
    public class IcazContext:DbContext
    {
        public IcazContext(DbContextOptions<IcazContext>options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Makale> Makales { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Konu> Konus { get; set; }
    }
}
