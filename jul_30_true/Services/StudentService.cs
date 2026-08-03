using jul_30_true.Model;

namespace jul_30_true.Services
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new List<Student> {
            new Student{ Id=1, FirstName="abc", LastName="aaaa", Phonee=777777, BatchId=101},
            new Student{ Id=2, FirstName="bob", LastName="thebuilder", Phonee=444444, BatchId=102},
            new Student{ Id=3, FirstName="Rahul", LastName="Patil", Phonee=654654, BatchId=101},
            new Student{ Id=4, FirstName="neha", LastName="Deshmukh", Phonee=333334, BatchId=102},
        };

            public List<Student> GetStudents()
            {
                return students;
            }
            public Student? GetStudentByID(int id)
            { 
                return students.FirstOrDefault(s=> s.Id == id);
            }
       public void AddStudent(Student student)
        {
            students.Add(student);
        }
    }

}

