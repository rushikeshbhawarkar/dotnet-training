using System.ComponentModel.DataAnnotations;

namespace assignment_08.Model
{
    public class Teacher
    {
        //[Key]
        public int TeacherId { get; set; }

        public ICollection<Course>? Courses { get; set; }




















        //[Required(ErrorMessage = "Name is required.")]
        //[StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        //public string Name { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Email address is required.")]
        //[EmailAddress(ErrorMessage = "Invalid email address format.")]
        //[StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        //public string Email { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Experience is required.")]
        //[Range(1, 40, ErrorMessage = "Experience must be between 1 and 40 years.")]
        //public int Experience { get; set; }
    }
}
