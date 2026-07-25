using System.ComponentModel.DataAnnotations;

namespace jul_24.Models
{
    public class Student
    {
        [Required (ErrorMessage ="User name is required")]
        public string Username {  get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public int RollNo { get; set; }
    }
}
