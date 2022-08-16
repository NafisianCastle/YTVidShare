using System.ComponentModel.DataAnnotations.Schema;
using System;
using VideoSharingService.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace VideoSharingService.Data.DTOs
{
    public class ReactionDTO :CreateReactionDTO
    {
        public int ReactionID { get; set; }

        public  VideoDTO Video { get; set; }
    }
}
 