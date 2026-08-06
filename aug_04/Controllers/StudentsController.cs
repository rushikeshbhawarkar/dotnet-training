using aug_04.Model;
using aug_04.Repository;
using Microsoft.AspNetCore.Mvc;

namespace aug_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService service;

        public StudentsController(IStudentService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = service.GetStudent(id);
            if (student == null)
            {
                return NotFound("Student not found");
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddS(Student student)
        {
            service.AddStudent(student);
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateS(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            var exisitng = service.GetStudent(id);

            if (exisitng == null)
            {
                return NotFound();
            }

            service.UpdateStudent(student);

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = service.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            service.DeleteStudent(id);

            return Ok("Student Deleted Successfully");
        }
    }
}
