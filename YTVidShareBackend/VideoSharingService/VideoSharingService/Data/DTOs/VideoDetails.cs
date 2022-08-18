using System.Collections.Generic;

namespace VideoSharingService.Data.DTOs
{
    public class VideoDetails
    {
        public string UploaderUserName { get; set; }
        public List<ReactorDTO> ReactorDTOs { get; set; }
    }
}
