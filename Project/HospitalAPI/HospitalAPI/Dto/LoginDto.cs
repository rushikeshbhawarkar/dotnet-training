using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Username is Required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }
    }
}