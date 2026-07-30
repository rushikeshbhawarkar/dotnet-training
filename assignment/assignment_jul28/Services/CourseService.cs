using assignment_jul28.Models;

namespace assignment_jul28.Services
{
    public class CourseService : ICourseService
    {
        private static List<Course> courses = new List<Course>()
        {
            new Course { Id = 101, Title = "Data Structures & Algorithms", Credits = 4, duration = 12 },
            new Course { Id = 102, Title = "Web Development with ASP.NET Core", Credits = 3, duration = 8 },
            new Course { Id = 103, Title = "Database Management Systems", Credits = 3, duration = 10 }
        };

        public List<Course> GetAllCourses()
        {
            return courses;
        }

        public Course? GetCourseById(int id)
        {
            return courses.FirstOrDefault(c => c.Id == id);
        }

        public Course AddCourse(Course course)
        {
            courses.Add(course);
            return course;
        }

        public bool UpdateCourseDuration(int id, int newDuration)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return false;
            }

            course.duration = newDuration;
            return true;
        }

        public bool DeleteCourse(int id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return false;
            }

            courses.Remove(course);
            return true;
        }
    }
}