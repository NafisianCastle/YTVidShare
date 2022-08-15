using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoSharingService.Data.Models
{
    public class Reaction
    {
        public int ReactionID { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public DateTime ReactingTime { get; set; }

        [ForeignKey(nameof(Video))]
        public int VideoID { get; set; }
        public virtual Video Video { get; set; }

        public int ReactedUserID { get; set; }

    }
}
