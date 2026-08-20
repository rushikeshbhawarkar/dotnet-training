using HospitalAPI.DTOs;
using HospitalAPI.Model;
using HospitalAPI.Repositories;

namespace HospitalAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public List<AppointmentDto> GetAll()
        {
            var appointments = _repository.GetAll();

            return appointments.Select(a => new AppointmentDto
            {
                AppointmentId = a.AppointmentId,
                AppointmentDate = a.AppointmentDate,
                Status = a.Status,
                Reason = a.Reason,
                PatientId = a.PatientId,
                PatientName = a.Patient?.Name,
                DoctorId = a.DoctorId,
                DoctorName = a.Doctor?.Name
            }).ToList();
        }

        public AppointmentDto? GetById(int id)
        {
            var appointment = _repository.GetById(id);

            if (appointment == null)
            {
                return null;
            }

            return new AppointmentDto
            {
                AppointmentId = appointment.AppointmentId,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status,
                Reason = appointment.Reason,
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient?.Name,
                DoctorId = appointment.DoctorId,
                DoctorName = appointment.Doctor?.Name
            };
        }

        public AppointmentDto Add(AppointmentDto appointmentDto)
        {
            var appointment = new Appointment
            {
                AppointmentDate = appointmentDto.AppointmentDate,
                Status = appointmentDto.Status,
                Reason = appointmentDto.Reason,
                PatientId = appointmentDto.PatientId,
                DoctorId = appointmentDto.DoctorId
            };

            var addedAppointment = _repository.Add(appointment);

            appointmentDto.AppointmentId = addedAppointment.AppointmentId;

            return appointmentDto;
        }

        public AppointmentDto? Update(int id, AppointmentDto appointmentDto)
        {
            var appointment = new Appointment
            {
                AppointmentDate = appointmentDto.AppointmentDate,
                Status = appointmentDto.Status,
                Reason = appointmentDto.Reason,
                PatientId = appointmentDto.PatientId,
                DoctorId = appointmentDto.DoctorId
            };

            var updatedAppointment = _repository.Update(id, appointment);

            if (updatedAppointment == null)
            {
                return null;
            }

            return new AppointmentDto
            {
                AppointmentId = updatedAppointment.AppointmentId,
                AppointmentDate = updatedAppointment.AppointmentDate,
                Status = updatedAppointment.Status,
                Reason = updatedAppointment.Reason,
                PatientId = updatedAppointment.PatientId,
                DoctorId = updatedAppointment.DoctorId
            };
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}