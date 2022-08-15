using System;
using System.Collections.Generic;

namespace VideoSharingService.Data.Models
{
    public class Video
    {
        public int VideoID { get; set; }
        public int UserID { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public DateTime dateTime { get; set; }

        public ICollection<Reaction> Reactions { get; set; }
    }
}
