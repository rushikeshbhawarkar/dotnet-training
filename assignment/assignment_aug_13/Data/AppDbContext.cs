using Microsoft.EntityFrameworkCore;
namespace assignment_aug_13.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Customer> Customer => Set<Customer>();
    }
}
