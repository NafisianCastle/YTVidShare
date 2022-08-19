using System;
using System.ComponentModel.DataAnnotations;

namespace VideoSharingService.Data.DTOs
{
    public class CreateVideoDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "URL is required")]
        public string Url { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required]
        public string UserID { get; set; }
    }
}
