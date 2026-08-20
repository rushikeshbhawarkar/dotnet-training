using HospitalAPI.Data;
using HospitalAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Appointment> GetAll()
        {
            return _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToList();
        }

        public Appointment? GetById(int id)
        {
            return _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefault(a => a.AppointmentId == id);
        }

        public Appointment Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return appointment;
        }

        public Appointment? Update(int id, Appointment appointment)//ho gaya ki phone lagana
        {
            var existingAppointment = _context.Appointments
                .FirstOrDefault(a => a.AppointmentId == id);

            if (existingAppointment == null)
            {
                return null;
            }

            existingAppointment.AppointmentDate = appointment.AppointmentDate;
            existingAppointment.Status = appointment.Status;
            existingAppointment.Reason = appointment.Reason;
            existingAppointment.PatientId = appointment.PatientId;
            existingAppointment.DoctorId = appointment.DoctorId;

            _context.SaveChanges();

            return existingAppointment;
        }

        public bool Delete(int id)
        {
            var appointment = _context.Appointments
                .FirstOrDefault(a => a.AppointmentId == id);

            if (appointment == null)
            {
                return false;
            }

            _context.Appointments.Remove(appointment);
            _context.SaveChanges();

            return true;
        }
    }
}