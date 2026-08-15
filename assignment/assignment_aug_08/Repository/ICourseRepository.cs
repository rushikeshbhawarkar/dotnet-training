using assignment_aug_08.Model;

namespace assignment_aug_08.Repository
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course? GetById(int id);
        Course Add(Course course);
        Course? Update(int id, Course course);
        bool Delete(int id);
    }
}
