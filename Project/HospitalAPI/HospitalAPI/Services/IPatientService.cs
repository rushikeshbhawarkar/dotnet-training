using HospitalAPI.DTOs;

namespace HospitalAPI.Services
{
    public interface IPatientService
    {
        List<PatientDto> GetAll();

       

        PatientDto? GetById(int id);






        PatientDto Add(PatientDto patientDto);

        PatientDto? Update(int id, PatientDto patientDto);

        bool Delete(int id);
    }
}//