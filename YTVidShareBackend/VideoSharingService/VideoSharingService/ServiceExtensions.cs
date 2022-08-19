using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VideoSharingService.Data;
using VideoSharingService.Data.Models;

namespace VideoSharingService
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection service)
        {
            var builder = service.AddIdentityCore<ApiUser>(q => q.User.RequireUniqueEmail = true);

            builder.AddEntityFrameworkStores<VidShareDbContext>().AddDefaultTokenProviders();
        }
    }
}
