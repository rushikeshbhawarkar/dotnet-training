using aug_17_rest.Model;
using Microsoft.EntityFrameworkCore;

namespace aug_17_rest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<User> Users12 { get; set; }
        //public DbSet<Order> Orders => Set<Order>();

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //one Product ->many OrderItems
        //    modelBuilder.Entity<OrderItems>().HasOne(o=>o.Product).WithMany(p=>p.OrderItems).HasForeignKey(o=>o.ProductId);

        //    //one Product ->many OrderItems
        //    modelBuilder.Entity<OrderItems>().HasOne(o => o.Order).WithMany(p => p.OrderItems).HasForeignKey(o => o.OrderId);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "admin", Password = "1234", Role = "Admin" },
                new User { Id = 2, UserName = "user1", Password = "1234", Role = "Customer" }
            );
        }

    }
}
