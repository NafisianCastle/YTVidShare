﻿namespace VideoSharingService.Data.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}