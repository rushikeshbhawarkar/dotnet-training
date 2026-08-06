using aug_03.Model;

namespace aug_03.Repository
{
    public interface IStudentService
    {
        List<Student> GetAll();

        Student GetStudent(int id);

        void AddStudent(Student student);

        void UpdateStudent(Student student);//update student

        void DeleteStudent(int id);
    }
}
