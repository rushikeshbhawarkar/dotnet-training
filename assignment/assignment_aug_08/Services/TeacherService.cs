using assignment_aug_08.Data;
using assignment_aug_08.Model;
using assignment_aug_08.Repository;

namespace assignment_aug_08.Services
{
    public class TeacherService : ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers.ToList();
        }

        public Teacher? GetById(int id)
        {
            return _context.Teachers.Find(id);
        }

        public Teacher Add(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return teacher;
        }

        public Teacher? Update(int id, Teacher teacher)
        {
            var existing = _context.Teachers.Find(id);
            if (existing == null) return null;

            existing.Name = teacher.Name;
            existing.Email = teacher.Email;
            existing.Experience = teacher.Experience;

            _context.SaveChanges();
            return existing;
        }

        public bool Delete(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher == null) return false;

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return true;
        }
    }
}