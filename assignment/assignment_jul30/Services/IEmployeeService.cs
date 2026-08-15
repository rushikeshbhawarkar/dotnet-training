using assignment_aug_02.Model;

namespace assignment_aug_02.Services
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);
        List<Employee> ViewAllEmployees();
        Employee ViewEmployeeDetails(int employeeId);
        //bool UpdateEmployeeInfo(Employee employee);
        bool DeleteEmployee(int id);
        List<Employee> GetEmployeeByDepartment(string employeeDepartment);

    }
}
