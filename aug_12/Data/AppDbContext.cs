using aug_12.Models;
using Microsoft.EntityFrameworkCore;
namespace aug_12.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                    UserName = "student",
                    Password = "1234",
                    Role = "Student"
                }
            );
        }


    }
}
