using assignment_jul16.Models.EmployeeManagementApp.Models;
using EmployeeManagementApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApp.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            var employees = new List<Employee>
            {
                new Employee { EmployeeId = 101, Name = "Alice Smith", Department = "IT", Salary = 75000, Email = "alice@company.com" },
                new Employee { EmployeeId = 102, Name = "Bob Johnson", Department = "HR", Salary = 62000, Email = "bob@company.com" },
                new Employee { EmployeeId = 103, Name = "Charlie Brown", Department = "Finance", Salary = 80000, Email = "charlie@company.com" }
            };

            return View(employees);
        }
    }
}