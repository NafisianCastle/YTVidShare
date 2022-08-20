using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideoSharingService.Data.Models;

namespace VideoSharingService.Data
{
    public class VidShareDbContext : IdentityDbContext<ApiUser>
    {
        public VidShareDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<ApiUser> ApiUsers { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Reaction> Reactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
        }
    }
}
