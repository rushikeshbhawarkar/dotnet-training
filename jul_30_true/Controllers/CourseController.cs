using jul_30_true.Model;
using jul_30_true.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jul_30_true.Controllers
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

        [HttpGet]
        public IActionResult GetCourse()
        {
            return Ok(_courseService.GetCourse());
        }

        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound("Course does not exist");
            }

            return Ok(course);
        }
    }
}