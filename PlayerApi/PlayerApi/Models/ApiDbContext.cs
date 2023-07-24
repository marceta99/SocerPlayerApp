using Microsoft.EntityFrameworkCore;

namespace PlayerApi.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
    }
}
