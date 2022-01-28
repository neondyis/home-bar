using Microsoft.EntityFrameworkCore;

namespace src
{
    public class BarContext : DbContext
    {
        public BarContext(DbContextOptions<BarContext> options) : base(options) { }
    }
}
