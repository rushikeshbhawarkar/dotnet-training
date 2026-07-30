using assignment_jul28.Models;
using assignment_jul28.Services;
using Microsoft.AspNetCore.Mvc;

namespace assignment_jul28.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/Course
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_courseService.GetAllCourses());
        }

        // GET: api/Course/101
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound($"Course with ID {id} not found.");
            }

            return Ok(course);
        }

        // POST: api/Course
        [HttpPost]
        public IActionResult Create(Course course)
        {
            var createdCourse = _courseService.AddCourse(course);
            return CreatedAtAction(nameof(GetById), new { id = createdCourse.Id }, createdCourse);
        }

        // PATCH: api/Course/101/duration
        [HttpPatch("{id}/duration")]
        public IActionResult UpdateDuration(int id, [FromBody] int newDuration)
        {
            var isUpdated = _courseService.UpdateCourseDuration(id, newDuration);
            if (!isUpdated)
            {
                return NotFound($"Course with ID {id} not found.");
            }

            return Ok($"Course duration updated to {newDuration} weeks successfully.");
        }

        // DELETE: api/Course/101
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _courseService.DeleteCourse(id);
            if (!isDeleted)
            {
                return NotFound($"Course with ID {id} not found.");
            }

            return NoContent();
        }
    }
}