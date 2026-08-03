using jul_30_true.Model;

namespace jul_30_true.Services
{
    public class CourseService : ICourseService
    {
        private static List<Course> courses = new List<Course>
        {
            new Course { CourseId = 1, CourseCredit = 2 },
            new Course { CourseId = 2, CourseCredit = 3 },
            new Course { CourseId = 3,  CourseCredit = 1 }
        };
        public List<Course> GetCourse()
        {
            return courses;
        }
        public Course GetCourseById(int courseId)
        {
            
            return courses.FirstOrDefault(s => s.CourseId == courseId); ;
        }


    }
}
