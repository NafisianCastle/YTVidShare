using System;
using System.ComponentModel.DataAnnotations;

namespace VideoSharingService.Data.DTOs
{
    public class CreateReactionDTO
    {
        public int Likes { get; set; }

        public int Dislikes { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReactingTime { get; set; }

        public int VideoID { get; set; }

        public int ReactedUserID { get; set; }
    }
}
