using Microsoft.AspNetCore.Mvc;
using EmployeeManagementApp.Models;

namespace EmployeeManagementApp.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            var departments = new List<Department>
            {
                new Department { DeptName = "IT", DeptHead = "David Miller", HeadContact = "+1-555-0192", HeadEmail = "david.head@company.com" },
                new Department { DeptName = "HR", DeptHead = "Sarah Connor", HeadContact = "+1-555-0144", HeadEmail = "sarah.head@company.com" },
                new Department { DeptName = "Finance", DeptHead = "Elena Rostova", HeadContact = "+1-555-0188", HeadEmail = "elena.head@company.com" }
            };

            return View(departments);
        }
    }
}