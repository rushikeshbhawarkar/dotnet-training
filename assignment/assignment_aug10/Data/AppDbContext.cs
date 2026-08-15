using assignment_aug10.Model;
using Microsoft.EntityFrameworkCore;
namespace assignment_aug10.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Booking>().HasOne(b => b.BookingId)
            //    .WithMany()
            //    .HasForeignKey(b => b.CustomerId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Customer)
                .WithMany()
                .HasForeignKey(b => b.CustomerId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Vehicle)
                .WithMany()
                .HasForeignKey(b => b.VehicleId);
        }
    }
}
