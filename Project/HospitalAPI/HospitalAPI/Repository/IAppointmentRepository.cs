using HospitalAPI.Model;

namespace HospitalAPI.Repositories
{
    public interface IAppointmentRepository
    {
        List<Appointment> GetAll();

        Appointment? GetById(int id);

        Appointment Add(Appointment appointment);

        Appointment? Update(int id, Appointment appointment);

        bool Delete(int id);
    }
}