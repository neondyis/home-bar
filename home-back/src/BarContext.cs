using Microsoft.EntityFrameworkCore;
using src.Models;


namespace src
{
    public class BarContext : DbContext
    {
        public BarContext(DbContextOptions<BarContext> options) : base(options) { }

        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Liquer> Liquers => Set<Liquer>();
    }
}
