using System.ComponentModel.DataAnnotations;

namespace aug_12.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(10, ErrorMessage = "10 Max letter can be stored in username")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(16, ErrorMessage = "16 Max letters can be stored in password")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role is required")]
        [StringLength(10, ErrorMessage = "10 max letters can be stored in role")]
        public string Role { get; set; } = string.Empty;
    }
}
