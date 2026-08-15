using assignment_aug_08.Model;
using assignment_aug_08.Repository;
using Microsoft.AspNetCore.Mvc;

namespace assignment_aug_08.Controllers
{
    [Route("api/teachers")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeachersController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var teachers = _teacherRepository.GetAll();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = _teacherRepository.GetById(id);
            if (teacher == null) return NotFound();
            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            var createdTeacher = _teacherRepository.Add(teacher);
            return Ok(createdTeacher);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Teacher teacher)
        {
            var updatedTeacher = _teacherRepository.Update(id, teacher);
            if (updatedTeacher == null) return NotFound();
            return Ok(updatedTeacher);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _teacherRepository.Delete(id);
            if (!result) return NotFound();
            return Ok();
        }
    }
}