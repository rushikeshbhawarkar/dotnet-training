using assignment_aug_08.Data;
using assignment_aug_08.Model;
using assignment_aug_08.Repository;

namespace assignment_aug_08.Services
{
    public class StudentService : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student? GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public Student Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public Student? Update(int id, Student student)
        {
            var existing = _context.Students.Find(id);
            if (existing == null) return null;

            existing.FirstName = student.FirstName;
            existing.LastName = student.LastName;
            existing.Email = student.Email;
            existing.Phone = student.Phone;
            existing.DateOfBirth = student.DateOfBirth;
            existing.BatchId = student.BatchId;

            _context.SaveChanges();
            return existing;
        }

        public bool Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return false;

            _context.Students.Remove(student);
            _context.SaveChanges();
            return true;
        }
    }
}