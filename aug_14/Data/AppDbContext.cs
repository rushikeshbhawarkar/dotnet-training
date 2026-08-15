using aug_14.Models;
using Microsoft.EntityFrameworkCore;

namespace aug_14.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<CutomerProduct> CustomerProducts => Set<CutomerProduct>();
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Configure Composite Primary Key
            modelBuilder.Entity<CutomerProduct>()
                .HasKey(cp => new { cp.CustomerId, cp.ProductId });

            // customer -- customerproduct
            modelBuilder.Entity<CutomerProduct>()
                .HasOne(cp => cp.Customer)
                .WithMany(c => c.CutomerProducts)
                .HasForeignKey(cp => cp.CustomerId);

            // 3. Configure Foreign Key for Product
            modelBuilder.Entity<CutomerProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.CutomerProducts)
                .HasForeignKey(cp => cp.ProductId);

            // email must be unique
            modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "admin",
                    Password = "1234",
                    Role = "Admin"
                },
                new User
                {
                    Id = 2,
                    UserName = "customer",
                    Password = "1234",
                    Role = "Customer"
                }
            );

        }

    }
}
