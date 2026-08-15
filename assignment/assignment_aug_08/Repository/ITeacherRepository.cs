using assignment_aug_08.Model;

namespace assignment_aug_08.Repository
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetAll();
        Teacher? GetById(int id);
        Teacher Add(Teacher teacher);
        Teacher? Update(int id, Teacher teacher);
        bool Delete(int id);
    }
}
