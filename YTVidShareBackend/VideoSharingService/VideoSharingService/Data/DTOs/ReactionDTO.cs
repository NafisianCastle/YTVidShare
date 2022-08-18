namespace VideoSharingService.Data.DTOs
{
    public class ReactionDTO : CreateReactionDTO
    {
        public int ReactionID { get; set; }

        public VideoDTO Video { get; set; }
    }
}
