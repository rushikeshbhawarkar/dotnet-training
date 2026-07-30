using jul_27.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jul_27.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee(){Id = 101, Name ="Rushikesh", Lastname="B", Dept="CSE", PhoneNum=123456}
        };
        [HttpGet]
        public IActionResult getEmployee()
        {
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public IActionResult getEmployeeById(int id)
        {
            var employee = employees.FirstOrDefault(x => x.Id == id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        //add new Employee record
        [HttpPost]
        public IActionResult AddEmployee (Employee employee)
        {
            employees.Add(employee);
            return Ok(employee);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id , Employee employee)
        {
            var employee1 = employees.FirstOrDefault(x=> x.Id == id);
            if(employee1 == null)
            {
                return NotFound();
            }
            return Ok(employee1);
        }
    }
}
