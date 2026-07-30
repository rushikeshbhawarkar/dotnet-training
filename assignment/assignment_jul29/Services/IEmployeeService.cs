using jul_29.Models;

namespace jul_29.Services
{
    public interface IEmployeeService
    {
        List<Employee> getEmployees();

        List<Employee> getEmployee(int deptid);

        Employee getEmployeeName(string Name);

        Employee addEmployee(Employee employee);
    }
}





