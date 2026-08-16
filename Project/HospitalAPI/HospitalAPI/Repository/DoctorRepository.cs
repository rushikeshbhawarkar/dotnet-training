using HospitalAPI.Data;
using HospitalAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }

        public Doctor? GetById(int id)
        {
            return _context.Doctors
                .FirstOrDefault(d => d.DoctorId == id);
        }

        public Doctor Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            return doctor;
        }

        public Doctor? Update(int id, Doctor doctor)
        {
            var existingDoctor = _context.Doctors
                .FirstOrDefault(d => d.DoctorId == id);

            if (existingDoctor == null)
            {
                return null;
            }

            existingDoctor.Name = doctor.Name;
            existingDoctor.Specialization = doctor.Specialization;
            existingDoctor.Email = doctor.Email;
            existingDoctor.Phone = doctor.Phone;
            existingDoctor.DepartmentId = doctor.DepartmentId;

            _context.SaveChanges();

            return existingDoctor;
        }

        public bool Delete(int id)
        {
            var doctor = _context.Doctors
                .FirstOrDefault(d => d.DoctorId == id);

            if (doctor == null)
            {
                return false;
            }

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();

            return true;
        }
    }
}