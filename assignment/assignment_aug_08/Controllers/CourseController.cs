using assignment_aug_08.Model;
using assignment_aug_08.Repository;
using Microsoft.AspNetCore.Mvc;

namespace assignment_aug_08.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var courses = _courseRepository.GetAll();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            var createdCourse = _courseRepository.Add(course);
            return Ok(createdCourse);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Course course)
        {
            var updatedCourse = _courseRepository.Update(id, course);
            if (updatedCourse == null) return NotFound();
            return Ok(updatedCourse);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _courseRepository.Delete(id);
            if (!result) return NotFound();
            return Ok();
        }
    }
}