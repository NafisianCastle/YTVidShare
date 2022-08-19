using System.ComponentModel.DataAnnotations;

namespace VideoSharingService.Data.DTOs
{
    public class CreateUserDTO : LoginDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        [StringLength(maximumLength: 20, ErrorMessage = "Username is too long")]
        public string Username { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
