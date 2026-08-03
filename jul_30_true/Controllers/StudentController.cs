using jul_30_true.Model;
using jul_30_true.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _30_Jul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_service.GetStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _service.GetStudentByID(id);
            if (student == null)
            {
                return NotFound("Student does not exists");
            }

            return Ok(student);
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _service.AddStudent(student);
            return Ok("Student Added");
        }
    }
}