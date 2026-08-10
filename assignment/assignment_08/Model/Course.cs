using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment_08.Model
{
    public class Course
    {
        // A Course Belong to One Teacher
        //[Key]
        public int CourseId { get; set; }

        public int TeacherId { get; set; }

        public Teacher? Teacher { get; set; }

        public ICollection<StudentCourse>? StudentCourses { get; set; }

















        //[Required(ErrorMessage = "Course name is required.")]
        //[StringLength(100, ErrorMessage = "Course name cannot exceed 100 characters.")]
        //public string CourseName { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Duration is required.")]
        //[Range(1, 24, ErrorMessage = "Duration must be between 1 and 24 months.")]
        //public int Duration { get; set; }

        //[Required(ErrorMessage = "Teacher assignment is required.")]
        //public int TeacherId { get; set; }

        ////// Navigation Property for Entity Framework
        ////[ForeignKey("TeacherId")]

    }
}
