using HospitalAPI.DTOs;
using HospitalAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = _service.GetAll();

            return Ok(departments);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var department = _service.GetById(id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpPost]
        public IActionResult Add(DepartmentDto departmentDto)
        {
            var department = _service.Add(departmentDto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = department.DepartmentId },
                department
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, DepartmentDto departmentDto)
        {
            var department = _service.Update(id, departmentDto);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}