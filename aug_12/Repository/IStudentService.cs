using aug_12.Models;

namespace aug_12.Repository
{
    public interface IStudentService
    {
        List<Student> GetStudents();

        Student? GetStudentById(int id);

        Student AddStudent(Student student);

        Student? UpdateStudent(Student student);

        bool DeleteStudent(int id);
    }
}