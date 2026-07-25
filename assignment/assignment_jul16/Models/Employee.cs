namespace assignment_jul16.Models
{
    namespace EmployeeManagementApp.Models
    {
        public class Employee
        {
            public int EmployeeId { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Department { get; set; } = string.Empty;
            public decimal Salary { get; set; }
            public string Email { get; set; } = string.Empty;
        }
    }
}
