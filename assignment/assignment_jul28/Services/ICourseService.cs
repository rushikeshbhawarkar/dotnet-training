using assignment_jul28.Models;

namespace assignment_jul28.Services
{
    public interface ICourseService
    {
        List<Course> GetAllCourses();

        Course? GetCourseById(int id);

        Course AddCourse(Course course);

        bool UpdateCourseDuration(int id, int newDuration);

        bool DeleteCourse(int id);
    }
}