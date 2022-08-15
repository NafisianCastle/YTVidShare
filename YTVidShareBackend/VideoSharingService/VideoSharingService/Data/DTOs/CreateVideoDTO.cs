using System.ComponentModel.DataAnnotations;
using System;

namespace VideoSharingService.Data.DTOs
{
    public class CreateVideoDTO
    {
        public string Url { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required")]
        public string Title { get; set; }
    }
}
