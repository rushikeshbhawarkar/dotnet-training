using Microsoft.EntityFrameworkCore;

namespace aug_06.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Product> products { get; set; }
    }
}
