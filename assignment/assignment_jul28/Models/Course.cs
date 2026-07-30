using System.ComponentModel.DataAnnotations;

namespace assignment_jul28.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Range(1, 10, ErrorMessage = "Credits must be between 1 and 10")]
        public int Credits { get; set; }

        [Range(1, 52, ErrorMessage = "Duration must be between 1 and 52 weeks")]
        public int duration { get; set; }
    }
}