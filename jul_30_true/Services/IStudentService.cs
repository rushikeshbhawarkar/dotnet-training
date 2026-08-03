using jul_30_true.Model;

namespace jul_30_true.Services
{
    public interface IStudentService
    {
      
            List<Student> GetStudents();

            Student GetStudentByID(int id);

            void AddStudent(Student student);
        }
    }

