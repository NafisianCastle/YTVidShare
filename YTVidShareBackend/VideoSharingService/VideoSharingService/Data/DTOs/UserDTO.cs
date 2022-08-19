using System.Collections.Generic;

namespace VideoSharingService.Data.DTOs
{
    public class UserDTO : CreateUserDTO
    {
        public string UserID { get; set; }
        public IList<VideoDTO> Videos { get; set; }
    }
}
