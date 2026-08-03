using assignment_aug_02.Model;
using assignment_aug_02.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment_aug_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            _employeeService.AddEmployee(employee);
            return Ok("Employee Created Successfully");
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeService.ViewAllEmployees());
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee_1 = _employeeService.ViewEmployeeDetails(id);
            if (employee_1 == null)
            {
                return NotFound("Employee Does Not Exist");
            }
            return Ok(employee_1);
        }

        //Delete Employee
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (_employeeService.DeleteEmployee(id) == false)
            {
                return NotFound("Employee Does not Exist");
            }
            else
            {
                return Ok("Employee Deleted Successfully");
            }

        }

        ////Get Employee By Department
        [HttpGet("department/{department}")]
        public IActionResult GetEmployeeByDepartment(string department)
        {
            var employees = _employeeService.GetEmployeeByDepartment(department);
            return Ok(employees);
        }
    }
}

