using HospitalAPI.Model;

namespace HospitalAPI.Repositories
{
    public interface IPatientRepository
    {
        List<Patient> GetAll();

        Patient? GetById(int id);

        Patient Add(Patient patient);

        Patient? Update(int id, Patient patient);

        bool Delete(int id);
    }
}