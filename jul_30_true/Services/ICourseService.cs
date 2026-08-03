using jul_30_true.Model;

namespace jul_30_true.Services
{
    public interface ICourseService
    {
        List<Course> GetCourse();
        Course GetCourseById(int id);

    }
}
