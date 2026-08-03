using assignment_aug_02.Model;

namespace assignment_aug_02.Services
{
//    •	Add a new employee.
//•	View all employees.
//•	View employee details.
//•	Update employee information.
//•	Delete an employee.

    public class EmployeeService : IEmployeeService
    {
        private static List<Employee> employeeList = new List<Employee>()
            {
                new Employee
                {
                    EmployeeID = 101,
                    FirstName = "John",
                    LastName = "Doe",
                    EmailAddress = "john.doe@company.com",
                    MobileNumber = "9876543210",
                    DateOfBirth = 19900515, // May 15, 1990
                    Gender = "Male",
                    Salary = 65000.00m,
                    DateOfJoining = 20220301, // March 1, 2022
                    Department = "IT",
                    Designation = "Software Engineer",
                    IsActive = true
                },
                new Employee
                {
                    EmployeeID = 102,
                    FirstName = "Jane",
                    LastName = "Smith",
                    EmailAddress = "jane.smith@company.com",
                    MobileNumber = "9876543211",
                    DateOfBirth = 19930822, // August 22, 1993
                    Gender = "Female",
                    Salary = 72000.00m,
                    DateOfJoining = 20210615, // June 15, 2021
                    Department = "HR",
                    Designation = "HR Manager",
                    IsActive = true
                },
                new Employee
                {
                    EmployeeID = 103,
                    FirstName = "Robert",
                    LastName = "Johnson",
                    EmailAddress = "robert.j@company.com",
                    MobileNumber = "9876543212",
                    DateOfBirth = 19881105, // November 5, 1988
                    Gender = "Male",
                    Salary = 85000.00m,
                    DateOfJoining = 20190110, // January 10, 2019
                    Department = "Finance",
                    Designation = "Financial Analyst",
                    IsActive = true
                },
                new Employee
                {
                    EmployeeID = 104,
                    FirstName = "Emily",
                    LastName = "Davis",
                    EmailAddress = "emily.davis@company.com",
                    MobileNumber = "9876543213",
                    DateOfBirth = 19950214, // February 14, 1995
                    Gender = "Female",
                    Salary = 58000.00m,
                    DateOfJoining = 20230901, // September 1, 2023
                    Department = "Marketing",
                    Designation = "Content Specialist",
                    IsActive = false
                },
                new Employee
                {
                    EmployeeID = 105,
                    FirstName = "Michael",
                    LastName = "Brown",
                    EmailAddress = "michael.b@company.com",
                    MobileNumber = "9876543214",
                    DateOfBirth = 19920730, // July 30, 1992
                    Gender = "Male",
                    Salary = 90000.00m,
                    DateOfJoining = 20201116, // November 16, 2020
                    Department = "IT",
                    Designation = "DevOps Engineer",
                    IsActive = true
                }
            };

        public List<Employee> ViewAllEmployees()
        {
            return employeeList;
        }

        public void AddEmployee(Employee employee)
        {
            employeeList.Add(employee);
        }

        public Employee ViewEmployeeDetails(int employeeId)
        {
            var employee = employeeList.FirstOrDefault(s => s.EmployeeID == employeeId);
            return employee;
        }
        
        public bool DeleteEmployee(int employeeId)
        {
           var employee_2 = employeeList.FirstOrDefault(s=>s.EmployeeID == employeeId);
            if(employee_2 != null)
            {
                return false;
            }
            employeeList.Remove(employee_2);
            return true;
        }

        public List<Employee> GetEmployeeByDepartment(string employeeDepartment)
        {
            List<Employee> employee_1 = employeeList.Where(s=>s.Department==employeeDepartment).ToList();
            return employee_1;
        }

    }
}
