using HospitalAPI.DTOs;

namespace HospitalAPI.Services
{
    public interface IAppointmentService
    {
        List<AppointmentDto> GetAll();

        AppointmentDto? GetById(int id);

        AppointmentDto Add(AppointmentDto appointmentDto);

        AppointmentDto? Update(int id, AppointmentDto appointmentDto);

        bool Delete(int id);
    }
}