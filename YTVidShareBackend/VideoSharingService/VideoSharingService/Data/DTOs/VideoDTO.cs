using System.Collections.Generic;

namespace VideoSharingService.Data.DTOs
{
    public class VideoDTO : CreateVideoDTO
    {
        public int VideoID { get; set; }
        public string ThumbnailUrl { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        public int DisLikeCount { get; set; }
        public IList<ReactionDTO> Reactions { get; set; }
        public string UserName { get; set; }

    }
}
