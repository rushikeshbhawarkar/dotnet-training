using aug_03.Model;
using aug_03.Repository;

namespace aug_03.Services
{
    public class StudentService : IStudentService
    {
        List<Student> students = new List<Student>
{
    new Student
    {
        Id = 1,
        Name = "Rushikesh",
        Age = 21,
        Course = "Computer Science",
        Email = "rushikesh@gmail.com"
    },
    new Student
    {
        Id = 2,
        Name = "Rahul",
        Age = 22,
        Course = "Information Technology",
        Email = "rahul@gmail.com"
    },
    new Student
    {
        Id = 3,
        Name = "Harshit",
        Age = 20,
        Course = "Data Science",
        Email = "harshit@gmail.com"
    },
    new Student
    {
        Id = 4,
        Name = "Ayush",
        Age = 23,
        Course = "Software Engineering",
        Email = "ayush@gmail.com"
    }
};
        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public Student GetStudent(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public void DeleteStudent(int id)
        {
            var existing = GetStudent(id);

            if (existing == null)
                throw new Exception("Student not found");

            students.Remove(existing);
        }

        public List<Student> GetAll()
        {
            return students;
            //throw new NotImplementedException();
        }

        //public Student GetStudent(int id)
        //{
        //    return students.FirstOrDefault(s => s.Id == id);
        //}

        public void UpdateStudent(Student student)
        {
            var existing = GetStudent(student.Id);
            if (existing != null)
            {
                throw new Exception("Student not Found");
            }
            existing.Age = student.Age;
        }


    }
}
