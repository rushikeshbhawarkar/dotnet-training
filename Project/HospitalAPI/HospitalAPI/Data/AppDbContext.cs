using Microsoft.EntityFrameworkCore;
namespace HospitalAPI.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options) :base(options)
        {
            
        }

    }
}
