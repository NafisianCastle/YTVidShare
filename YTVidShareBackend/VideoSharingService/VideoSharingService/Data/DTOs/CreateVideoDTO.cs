using System.ComponentModel.DataAnnotations;
using System;

namespace VideoSharingService.Data.DTOs
{
    public class CreateVideoDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "URL is required")]
        public string Url { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UploadDate { get; set; }
    }
}
