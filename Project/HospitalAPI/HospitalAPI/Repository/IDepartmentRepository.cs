using HospitalAPI.Model;

namespace HospitalAPI.Repositories
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();

        Department? GetById(int id);

        Department Add(Department department);

        Department? Update(int id, Department department);

        bool Delete(int id);
    }
}