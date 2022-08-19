using System;
using System.ComponentModel.DataAnnotations;

namespace VideoSharingService.Data.DTOs
{
    public class CreateReactionDTO
    {
        [Required]
        public bool Value { get; set; }
        [Required]
        public int VideoID { get; set; }
        [Required]
        public DateTime ReactingTime { get; set; }
        [Required]
        public string ReactedUserID { get; set; }
    }
}
