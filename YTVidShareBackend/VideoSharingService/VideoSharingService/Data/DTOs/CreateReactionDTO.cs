using System;
using System.ComponentModel.DataAnnotations;

namespace VideoSharingService.Data.DTOs
{
    public class CreateReactionDTO
    {
        public bool Value { get; set; }

        public int VideoID { get; set; }

        public string ReactedUserID { get; set; }
    }
}
