using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoSharingService.Data.Models
{
    public class Reaction
    {
        public int ReactionID { get; set; }
        public int Value { get; set; }
        public DateTime ReactingTime { get; set; }

        [ForeignKey(nameof(Video))]
        public Video Video { get; set; }
        public int VideoID { get; set; }

        [ForeignKey(nameof(User))]
        public User User { get; set; }
        public int UserID { get; set; }
    }
}
