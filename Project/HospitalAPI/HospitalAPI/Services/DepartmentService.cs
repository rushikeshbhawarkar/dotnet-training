using HospitalAPI.DTOs;
using HospitalAPI.Model;
using HospitalAPI.Repositories;

namespace HospitalAPI.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public List<DepartmentDto> GetAll()
        {
            var departments = _repository.GetAll();

            return departments.Select(department => new DepartmentDto
            {
                Name = department.DepartmentName,
                Description = department.Description
            }).ToList();
        }

        public DepartmentDto? GetById(int id)
        {
            var department = _repository.GetById(id);

            if (department == null)
            {
                return null;
            }

            return new DepartmentDto
            {
                Name = department.DepartmentName,
                Description = department.Description
            };
        }

        public DepartmentDto Add(DepartmentDto departmentDto)
        {
            // DTO → Model

            var department = new Department
            {
                DepartmentName = departmentDto.Name,
                Description = departmentDto.Description
            };

            var savedDepartment = _repository.Add(department);

            // Model → DTO

            return new DepartmentDto
            {
                Name = savedDepartment.DepartmentName,
                Description = savedDepartment.Description
            };
        }

        public DepartmentDto? Update(
            int id,
            DepartmentDto departmentDto)
        {
            // DTO → Model

            var department = new Department
            {
                DepartmentName = departmentDto.Name,
                Description = departmentDto.Description
            };

            var updatedDepartment =
                _repository.Update(id, department);

            if (updatedDepartment == null)
            {
                return null;
            }

            // Model → DTO

            return new DepartmentDto
            {
                Name = updatedDepartment.DepartmentName,
                Description = updatedDepartment.Description
            };
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}