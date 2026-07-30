using jul_29.Models;
using jul_29.Services;

namespace jul_29.Services
{
    public class EmployeeService : IEmployeeService
    {
        private static List<Employee> employees = new List<Employee>() {
            new Employee{ Id=101, Name="Rahul", PhoneN=723444, Email="rahul@gmail.com", DeptId=11 },
            new Employee{ Id=102, Name="Rushi", PhoneN=922224, Email="rushi@gmail.com", DeptId=11 },
            new Employee{ Id=103, Name="Shubh", PhoneN=611111, Email="sc@gmail.com", DeptId=12 },
            new Employee{ Id=104, Name="Harshit", PhoneN=0000003, Email="harshit@gmail.com", DeptId=13 },
        };

        public List<Employee> getEmployees()
        {
            return employees;
        }

        //public Employee? getEmployee(int deptid)
        //{
        //    return employees.FirstOrDefault(e => e.DeptId == deptid);
        //}

        public Employee? getEmployeeName(string Name)
        {
            return employees.FirstOrDefault(e => e.Name == Name);
        }

        public List<Employee> getEmployee(int deptid)
        {
            List<Employee> emp = employees.FindAll(a => a.DeptId == deptid);
            return emp;
            //return employees.Where(e => e.DeptId == deptid).ToList();
        }

        public Employee addEmployee(Employee employee)
        {
            employees.Add(employee);
            return employee;
        }
    }
}





