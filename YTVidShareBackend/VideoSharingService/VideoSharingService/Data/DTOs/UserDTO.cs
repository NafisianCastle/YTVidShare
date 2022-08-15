using System;
using System.ComponentModel.DataAnnotations;

namespace VideoSharingService.Data.DTOs
{
    public class UserDTO
    {
        public int UserID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength:20,ErrorMessage ="Username is too long")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
