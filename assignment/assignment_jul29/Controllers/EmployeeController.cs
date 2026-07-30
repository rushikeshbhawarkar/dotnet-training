using jul_29.Models;
using jul_29.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jul_29.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        // Constructor enabled so Dependency Injection injects IEmployeeService
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.getEmployees());
        }

        //[HttpGet("{deptid}")]
        //public IActionResult GetById(int deptid)
        //{
        //    var employee = _service.getEmployee(deptid);
        //    if (employee == null)
        //    {
        //        return NotFound("Employee with id not found ");
        //    }

        //    return Ok(employee);
        //}

        [HttpGet("{deptid}")]
        public IActionResult GetById(int deptid)
        {
            var deptEmployees = _service.getEmployee(deptid);
            if (!deptEmployees.Any())
            {
                return NotFound("No employees found for this department ID");
            }

            return Ok(deptEmployees);
        }

        [HttpGet("{Name}")]
        public IActionResult GetByName(string Name)
        {
            return Ok(_service.getEmployeeName(Name));
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            var res = _service.addEmployee(employee);
            return Ok(res);
        }
    }
}




