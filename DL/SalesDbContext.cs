using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext() : base() { }
        public SalesDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}
