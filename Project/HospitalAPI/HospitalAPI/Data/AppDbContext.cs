using HospitalAPI.Model;
using Microsoft.EntityFrameworkCore;
namespace HospitalAPI.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options) :base(options)
        {
            
        }
        public DbSet<Appointment> Appointments => Set<Appointment>();

        public DbSet<AppointmentHistory> AppointmentHistory => Set<AppointmentHistory>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Department 1 → Many Doctors
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Department)
                .WithMany(dept => dept.Doctors)
                .HasForeignKey(d => d.DepartmentId);

            // Patient 1 → Many Appointments
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);


            // Doctor 1 → Many Appointments
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);


            // Appointment 1 → Many AppointmentHistories
            modelBuilder.Entity<AppointmentHistory>()
                .HasOne(ah => ah.Appointment)
                .WithMany(a => a.AppointmentHistories)
                .HasForeignKey(ah => ah.AppointmentId);
        }
    }
}
