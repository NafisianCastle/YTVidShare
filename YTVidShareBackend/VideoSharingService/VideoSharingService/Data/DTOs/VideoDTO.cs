using System.ComponentModel.DataAnnotations.Schema;
using System;
using VideoSharingService.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace VideoSharingService.Data.DTOs
{
    public class VideoDTO:CreateVideoDTO
    {
        public int VideoID { get; set; }
        
        public int ViewCount { get; set; }

        public IList<ReactionDTO> Reactions { get; set; }

        public  UserDTO User { get; set; }
    }
}
