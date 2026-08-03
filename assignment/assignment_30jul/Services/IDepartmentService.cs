using assignment_aug_02.Model;
namespace assignment_aug_02.Services
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments(); 
        void AddDepartment(Department department);
        Department GetDepartmentById(int departmentId);
        bool DeleteDepartment(int departmentId);
        
        //update department


    }
}
