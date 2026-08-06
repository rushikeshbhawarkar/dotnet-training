using aug_04.Model;

namespace aug_04.Repository
{
    public interface IStudentService
    {
        List<Student> GetAll();

        Student GetStudent(int id);

        void AddStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(int id);

    }
}
