using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace VideoSharingService.Data.Models
{
    public class ApiUser:IdentityUser
    {
         public IList<Video> Videos { get; set; }
    }
}
