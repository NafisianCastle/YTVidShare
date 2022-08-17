using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideoSharingService.Data.Models;

namespace VideoSharingService.Data
{
    public class VidShareDbContext : IdentityDbContext
    {
        public VidShareDbContext(DbContextOptions options) : base(options)
        {
        }



        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Reaction> Reactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.Entity<User>().HasData(
               new User
               {
                   UserID = 1,
                   Username = "Admin",
                   Email = "admin@vidshare.com",
                   Password = "admin@1234",
                   CreatedAt = System.DateTime.Now
               }
            );
        }
    }
}
