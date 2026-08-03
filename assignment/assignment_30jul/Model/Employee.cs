using System;

namespace assignment_aug_02.Model
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public int DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public int DateOfJoining { get; set; }
        public string Department { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
