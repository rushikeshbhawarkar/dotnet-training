using aug_12.Models;
using aug_12.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aug_12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Student")]
        public IActionResult GetAll()
        {
            var students = _studentService.GetStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Student")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound("Student not found");
            }
            return Ok(student);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddStudent(Student student)
        {
            var student1 = _studentService.AddStudent(student);
            return Ok(student1);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest("ID mismatch");
            }

            var updatedStudent = _studentService.UpdateStudent(student);
            if (updatedStudent == null)
            {
                return NotFound("Student not found");
            }

            return Ok(updatedStudent);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteStudent(int id)
        {
            var isDeleted = _studentService.DeleteStudent(id);
            if (!isDeleted)
            {
                return NotFound("Student not found");
            }

            return Ok("Student deleted successfully");
        }
    }
}