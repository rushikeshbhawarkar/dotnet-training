using HospitalAPI.Model;

namespace HospitalAPI.Repositories
{
    public interface IDoctorRepository
    {
        List<Doctor> GetAll();

        Doctor? GetById(int id);

        Doctor Add(Doctor doctor);

        Doctor? Update(int id, Doctor doctor);

        bool Delete(int id);
    }
}