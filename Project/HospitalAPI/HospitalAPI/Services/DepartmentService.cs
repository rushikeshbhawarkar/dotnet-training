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

            return departments.Select(d => new DepartmentDto
            {
                DepartmentId = d.DepartmentId,
                DepartmentName = d.DepartmentName,
                Description = d.Description
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
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                Description = department.Description
            };
        }

        public DepartmentDto Add(DepartmentDto departmentDto)
        {
            var department = new Department
            {
                DepartmentName = departmentDto.DepartmentName,
                Description = departmentDto.Description
            };

            var addedDepartment = _repository.Add(department);

            departmentDto.DepartmentId = addedDepartment.DepartmentId;

            return departmentDto;
        }

        public DepartmentDto? Update(int id, DepartmentDto departmentDto)
        {
            var department = new Department
            {
                DepartmentName = departmentDto.DepartmentName,
                Description = departmentDto.Description
            };

            var updatedDepartment = _repository.Update(id, department);

            if (updatedDepartment == null)
            {
                return null;
            }

            return new DepartmentDto
            {
                DepartmentId = updatedDepartment.DepartmentId,
                DepartmentName = updatedDepartment.DepartmentName,
                Description = updatedDepartment.Description
            };
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}