using System;
using System.ComponentModel.DataAnnotations;

namespace VideoSharingService.Data.DTOs
{
    public class CreateVideoDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "URL is required")]
        public string Url { get; set; }

        public string ThumbnailUrl { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public DateTime UploadDate { get; set; }

        [Required]
        public string UserEmail { get; set; }
    }
}
