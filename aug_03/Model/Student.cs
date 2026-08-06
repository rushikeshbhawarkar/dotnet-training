using System.ComponentModel.DataAnnotations;

namespace aug_03.Model
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Student Name is required")]
        [StringLength(30, ErrorMessage = "Student name must not be more than 30 letter")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Student Age is required")]
        [Range(18, 25, ErrorMessage = "Student age must be between 18 to 25")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Student Course is required")]
        public string Course { get; set; }

        [Required(ErrorMessage = "Student Mail id is required")]
        [EmailAddress(ErrorMessage = "Student mail is incorrect")]
        public string Email { get; set; }
    }
}
