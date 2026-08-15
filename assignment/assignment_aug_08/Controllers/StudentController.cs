using assignment_aug_08.Model;
using assignment_aug_08.Repository;
using Microsoft.AspNetCore.Mvc;

namespace assignment_aug_08.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var students = _studentRepository.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            var createdStudent = _studentRepository.Add(student);
            return Ok(createdStudent);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Student student)
        {
            var updatedStudent = _studentRepository.Update(id, student);
            if (updatedStudent == null) return NotFound();
            return Ok(updatedStudent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _studentRepository.Delete(id);
            if (!result) return NotFound();
            return Ok();
        }
    }
}