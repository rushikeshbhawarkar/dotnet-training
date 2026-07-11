using System;

namespace LeaveManagement
{
    // Abstract base class
    public abstract class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double LeaveBalance { get; protected set; }

        public void DisplayDetails()
        {
            Console.WriteLine($"Employee Id   : {EmployeeId}");
            Console.WriteLine($"Name          : {Name}");
            Console.WriteLine($"Department    : {Department}");
            Console.WriteLine($"Leave Balance : {LeaveBalance} days");
            Console.WriteLine();
        }

        public abstract void SetLeaveBalance();
    }
}