using HospitalAPI.Data;
using HospitalAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public Patient? GetById(int id)
        {
            return _context.Patients.FirstOrDefault(p => p.PatientId == id);
        }

        public Patient Add(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();

            return patient;
        }

        public Patient? Update(int id, Patient patient)
        {
            var existingPatient = _context.Patients
                .FirstOrDefault(p => p.PatientId == id);

            if (existingPatient == null)
            {
                return null;
            }

            existingPatient.Name = patient.Name;
            existingPatient.DateOfBirth = patient.DateOfBirth;
            existingPatient.Gender = patient.Gender;
            existingPatient.Email = patient.Email;
            existingPatient.Phone = patient.Phone;
            existingPatient.Address = patient.Address;

            _context.SaveChanges();

            return existingPatient;
        }

        public bool Delete(int id)
        {
            var patient = _context.Patients
                .FirstOrDefault(p => p.PatientId == id);

            if (patient == null)
            {
                return false;
            }

            _context.Patients.Remove(patient);
            _context.SaveChanges();

            return true;
        }
    }
}