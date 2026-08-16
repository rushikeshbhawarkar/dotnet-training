using HospitalAPI.DTOs;

namespace HospitalAPI.Services
{
    public interface IDoctorService
    {
        List<DoctorDto> GetAll();

        DoctorDto? GetById(int id);

        DoctorDto Add(DoctorDto doctorDto);

        DoctorDto? Update(int id, DoctorDto doctorDto);

        bool Delete(int id);
    }
}