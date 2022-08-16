using System;
using System.Collections.Generic;

namespace VideoSharingService.Data.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } 

        public IList<Video> Videos {get; set; }
    }
}
