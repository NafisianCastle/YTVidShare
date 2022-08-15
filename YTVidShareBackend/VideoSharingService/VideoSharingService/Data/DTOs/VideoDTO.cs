using System.ComponentModel.DataAnnotations.Schema;
using System;
using VideoSharingService.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace VideoSharingService.Data.DTOs
{
    public class VideoDTO
    {
        public int VideoID { get; set; }
        public string Url { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public DateTime UploadDate { get; set; }
        public int ViewCount { get; set; }
    }
}
