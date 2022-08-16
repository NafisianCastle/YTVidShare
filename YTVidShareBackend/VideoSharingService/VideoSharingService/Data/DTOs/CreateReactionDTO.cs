using System;
using System.ComponentModel.DataAnnotations;

namespace VideoSharingService.Data.DTOs
{
    public class CreateReactionDTO
    {
        public bool Value { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReactingTime { get; set; }

        public int VideoID { get; set; }

        public int ReactedUserID { get; set; }
    }
}
