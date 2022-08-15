using Microsoft.EntityFrameworkCore;

namespace VideoSharingService.Data
{
    public class VidShareDbContext : DbContext
    {
        public VidShareDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Models.User> Users { get; set; }

    }
}
