using System;
using System.Collections.Generic;

namespace LeaveManagement
{
    class Program
    {
        static void Main(string[] args)
        {
    
            List<Employee> employees = new List<Employee>
            {
                new PermanentEmployee(101, "Alice", "IT", 24),
                new ContractEmployee(102, "Bob", "HR", 12),
                new PermanentEmployee(103, "Charlie", "Finance", 24),
                new ContractEmployee(104, "David", "IT", 12)
            };

          
            Console.WriteLine("=== All Employees ===");
            foreach (Employee emp in employees)               
            {
                emp.DisplayDetails();
            }

        
            List<LeaveRequest> leaveRequests = new List<LeaveRequest>
            {
                new LeaveRequest { LeaveId = 1, EmployeeId = 101, NumberOfDays = 5, Reason = "Vacation" },
                new LeaveRequest { LeaveId = 2, EmployeeId = 102, NumberOfDays = 2, Reason = "Medical" },
                new LeaveRequest { LeaveId = 3, EmployeeId = 103, NumberOfDays = 3, Reason = "Personal" }
            };

    
            Console.WriteLine("=== All Leave Requests ===");
            foreach (LeaveRequest lr in leaveRequests)
            {
                lr.DisplayLeave();
            }

            Console.WriteLine("=== Permanent Employees Only ===");
            foreach (Employee emp in employees)
            {
                if (emp is PermanentEmployee)           
                {
                    emp.DisplayDetails();
                }
            }

            
            Console.WriteLine("=== Employee with Id 103 ===");

            Employee found = null;
            foreach (Employee emp in employees)
            {
                if (emp.EmployeeId == 103)
                {
                    found = emp;
                    break;
                }
            }

            if (found != null)
            {
                found.DisplayDetails();
            }
            else
            {
                Console.WriteLine("Employee with Id 103 not found.");
            }

            
            Console.WriteLine("Total Employees : " + employees.Count);     
            Console.WriteLine("Total Leave Requests : " + leaveRequests.Count);

            Console.ReadLine();
        }
    }
}