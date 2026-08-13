using System.ComponentModel.DataAnnotations;

namespace aug_12.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "30 Max Letters are allowed")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 25, ErrorMessage = "Age mustbe between 18 to 25")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Mail id is required")]
        [StringLength(30, ErrorMessage = "20 Max Letters are allowed")]
        [EmailAddress(ErrorMessage = "Mail id is incorrect")]
        public string Mail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Phone number is incorrect")]
        public string Phonenumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course name is required")]
        [StringLength(30, ErrorMessage = "30 Max Letters are allowed")]
        public string Course { get; set; } = string.Empty;
    }
}
