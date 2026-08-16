using HospitalAPI.DTOs;

namespace HospitalAPI.Services
{
    public interface IDepartmentService
    {
        List<DepartmentDto> GetAll();

        DepartmentDto? GetById(int id);

        DepartmentDto Add(DepartmentDto departmentDto);

        DepartmentDto? Update(int id, DepartmentDto departmentDto);

        bool Delete(int id);
    }
}