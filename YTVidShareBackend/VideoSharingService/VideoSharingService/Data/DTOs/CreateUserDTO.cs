using System.ComponentModel.DataAnnotations;
using System;

namespace VideoSharingService.Data.DTOs
{
    public class CreateUserDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength:20,ErrorMessage ="Username is too long")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
