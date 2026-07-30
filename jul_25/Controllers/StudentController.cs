using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using jul_25.Model;

namespace jul_25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//provides automatic model validation 
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new()
        {
            new Student
            {
                id = 1,
                Name = "Kartik",
                Age = 20,
                Department = "Computer Sciene"

            },
            new Student
            {
                id = 2,
                Name = "Rahul",
                Age = 20,
                Department = "Computer Sciene"

            },
            new Student
            {
                id = 3,
                Name = "Ram",
                Age = 20,
                Department = "Computer Sciene"

            }
        };
        [HttpGet]
        public IActionResult GetStudent()
        {
            return Ok(students);//200 code
        }
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.id == id);
            if(student == null)
            {
                return NotFound();
            }    
            return Ok(student);
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            students.Add(student);
            return CreatedAtAction(nameof(GetStudent),
                new { id = student.id }, students);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student updateStudent)
        {
            var student = students.FirstOrDefault(s => s.id == id);
            if (student == null)
                return NotFound();

            student.Age = updateStudent.Age;

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.id == id);
            if (student == null)
                return NotFound();

            students.Remove(student);
            return NoContent();
        }
    }
}
