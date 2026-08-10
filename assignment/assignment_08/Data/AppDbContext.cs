using assignment_08.Model;
using Microsoft.EntityFrameworkCore;

namespace assignment_08.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Batch> Batches => Set<Batch>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<StudentCourse> StudentCourses => Set<StudentCourse>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One Batch → Many Students

            // One Teacher → Many Courses

            // Many Students ↔ Many Courses


            // One Batch → Many Students
            modelBuilder.Entity<Student>()
                .HasOne(o=>o.Batch)
                .WithMany(b=>b.Students)
                .HasForeignKey(s => s.BatchId);


            // One Teacher → Many Courses
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId);

            // Many Students ↔ Many Courses
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
        }

    }
}
