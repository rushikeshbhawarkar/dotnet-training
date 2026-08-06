
using aug_04.Model;
using Microsoft.EntityFrameworkCore;

namespace aug_04.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
