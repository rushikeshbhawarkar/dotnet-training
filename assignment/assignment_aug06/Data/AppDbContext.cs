using assignment_06.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment_06.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Order> orders { get; set; }
    }
}
