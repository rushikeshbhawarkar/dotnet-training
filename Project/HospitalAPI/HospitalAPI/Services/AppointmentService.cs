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

            return appointments.Select(appointment => new AppointmentDto
            {
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status,
                Reason = appointment.Reason
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
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status,
                Reason = appointment.Reason
            };
        }

        public AppointmentDto Add(AppointmentDto appointmentDto)
        {
            // DTO → Model

            var appointment = new Appointment
            {
                PatientId = appointmentDto.PatientId,
                DoctorId = appointmentDto.DoctorId,
                AppointmentDate = appointmentDto.AppointmentDate,
                Status = appointmentDto.Status,
                Reason = appointmentDto.Reason
            };

            // Business logic will go here

            var savedAppointment = _repository.Add(appointment);

            // Model → DTO

            return new AppointmentDto
            {
                PatientId = savedAppointment.PatientId,
                DoctorId = savedAppointment.DoctorId,
                AppointmentDate = savedAppointment.AppointmentDate,
                Status = savedAppointment.Status,
                Reason = savedAppointment.Reason
            };
        }

        public AppointmentDto? Update(
            int id,
            AppointmentDto appointmentDto)
        {
            // DTO → Model

            var appointment = new Appointment
            {
                PatientId = appointmentDto.PatientId,
                DoctorId = appointmentDto.DoctorId,
                AppointmentDate = appointmentDto.AppointmentDate,
                Status = appointmentDto.Status,
                Reason = appointmentDto.Reason
            };

            var updatedAppointment =
                _repository.Update(id, appointment);

            if (updatedAppointment == null)
            {
                return null;
            }

            // Model → DTO

            return new AppointmentDto
            {
                PatientId = updatedAppointment.PatientId,
                DoctorId = updatedAppointment.DoctorId,
                AppointmentDate = updatedAppointment.AppointmentDate,
                Status = updatedAppointment.Status,
                Reason = updatedAppointment.Reason
            };
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}