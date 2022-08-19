using System.ComponentModel.DataAnnotations;

namespace VideoSharingService.Data.DTOs
{
    public class LoginDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
