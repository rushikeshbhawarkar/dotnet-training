using aug_12.Data;
using aug_12.Models;
using aug_12.Repository;

namespace aug_12.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext context;

        public StudentService(AppDbContext context)
        {
            this.context = context;
        }

        public Student AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return student;
        }

        public Student? GetStudentById(int id)
        {
            return context.Students.Find(id);
        }

        public List<Student> GetStudents()
        {
            return context.Students.ToList();
        }

        public Student? UpdateStudent(Student student)
        {
            var existingStudent = context.Students.Find(student.Id);
            if (existingStudent == null)
            {
                return null;
            }

            // Update entity properties
            context.Entry(existingStudent).CurrentValues.SetValues(student);
            context.SaveChanges();

            return existingStudent;
        }

        public bool DeleteStudent(int id)
        {
            var student = context.Students.Find(id);
            if (student == null)
            {
                return false;
            }

            context.Students.Remove(student);
            context.SaveChanges();
            return true;
        }
    }
}