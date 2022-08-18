using System.ComponentModel.DataAnnotations;

namespace VideoSharingService.Data.DTOs
{
    public class UpdateVideoDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        public int DisLikeCount { get; set; }
        [Required]
        public int UserID { get; set; }
    }
}
