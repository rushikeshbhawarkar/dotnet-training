using aug_07.Model;
using Microsoft.EntityFrameworkCore;

namespace aug_07.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Product> Products => Set<Product>();

        public DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one Product ->many OrderItems
            modelBuilder.Entity<OrderItems>().HasOne(o=>o.Product).WithMany(p=>p.OrderItems).HasForeignKey(o=>o.ProductId);

            //one Product ->many OrderItems
            modelBuilder.Entity<OrderItems>().HasOne(o => o.Order).WithMany(p => p.OrderItems).HasForeignKey(o => o.OrderId);
        }

    }
}
