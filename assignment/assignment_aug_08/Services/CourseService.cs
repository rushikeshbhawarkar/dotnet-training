using assignment_aug_08.Data;
using assignment_aug_08.Model;
using assignment_aug_08.Repository;

namespace assignment_aug_08.Services
{
    public class CourseService : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course? GetById(int id)
        {
            return _context.Courses.Find(id);
        }

        public Course Add(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        public Course? Update(int id, Course course)
        {
            var existing = _context.Courses.Find(id);
            if (existing == null) return null;

            existing.CourseName = course.CourseName;
            existing.Duration = course.Duration;
            existing.TeacherId = course.TeacherId;

            _context.SaveChanges();
            return existing;
        }

        public bool Delete(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null) return false;

            _context.Courses.Remove(course);
            _context.SaveChanges();
            return true;
        }
    }
}