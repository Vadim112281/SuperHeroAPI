using Microsoft.EntityFrameworkCore;
using SuperHero.Models;

namespace SuperHero.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> optnios): base(optnios) { }

        public DbSet<HeroSuper> SuperHeroes { get; set; }
    }
}
