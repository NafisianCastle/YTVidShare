using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoSharingService.Data.Models
{
    public class Video
    {
        public int VideoID { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public DateTime UploadDate { get; set; }
        public int ViewCount { get; set; }
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
