using assignment_aug_02.Model;

namespace assignment_aug_02.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly List<Department> _departments = new()
    {
        new Department
        {
            DepartmentId = 1,
            Name = "Human Resources",
            Code = "HR",
            Status = "Active"
        },
        new Department
        {
            DepartmentId = 2,
            Name = "Information Technology",
            Code = "IT",
            Status = "Active"
        },
        new Department
        {
            DepartmentId = 3,
            Name = "Marketing & Sales",
            Code = "MKT",
            Status = "Inactive"
        }
    };

        public List<Department> GetDepartments()
        {
            return _departments;
        }

        public void AddDepartment(Department department)
        {
          

            _departments.Add(department);
        }

        public Department GetDepartmentById(int departmentId)
        {
            return _departments.FirstOrDefault(d => d.DepartmentId == departmentId);
        }

        public bool DeleteDepartment(int departmentId)
        {
            var department = GetDepartmentById(departmentId);
            if (department == null)
            {
                return false;
            }

            return _departments.Remove(department);
        }
    }
}
