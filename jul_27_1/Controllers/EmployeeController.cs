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
            new Employee(){Id = 101, Name ="Rushikesh", Lastname="B", Dept="CSE", PhoneNum=123456, Profile="Student", Location="Wardha"}
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
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        //add new Employee record
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return Ok(employee);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            var employee1 = employees.FirstOrDefault(x => x.Id == id);
            if (employee1 == null)
            {
                return NotFound();
            }
            employee1.Lastname = employee.Lastname;
            return Ok(employee1);

        }

        [HttpGet("Dept/{dept}")]
        public IActionResult GetEmployeeByDept(string dept)
        {
            var result = employees.Where(s => s.Dept.Equals(dept, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!result.Any())
            {
                return NotFound("Not employee found under this dept");
            }
            return Ok(result);
        }
        [HttpGet("Profile/{prof}")]
        public IActionResult GetEmployeeByProfile(string prof)
        {
            //var x_1 = employees.Where(y => y.Profile(prof, StringComparison.OrdinalIgnoreCase)).ToList();
            var employee = employees.FirstOrDefault(x => x.Profile == prof);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet("Location/{loc}")]
        public IActionResult GetEmployeeByLocation(string loc)
        {
            //var x_1 = employees.Where(y => y.Profile(prof, StringComparison.OrdinalIgnoreCase)).ToList();
            var employee = employees.FirstOrDefault(x => x.Location == loc);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


    }
}
