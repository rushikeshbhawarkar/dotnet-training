using assignment_aug_02.Model;
using assignment_aug_02.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace assignment_aug_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        //        •	Create Department 
        //•	Get All Departments 
        //•	Get Department by ID 
        //•	Update Department 
        //•	Delete Department

        [HttpPost]//----------------------------------------------------------
        public IActionResult CreateDepartment(Department department)
        {
            _departmentService.AddDepartment(department);
            return Ok("Department added successfully");
        }

        [HttpGet]//-------------------------------------------------
        public IActionResult GetAllDepartment()
        {
            var x =_departmentService.GetDepartments();
            return Ok(x);
        }

        // • Get Department by ID--------------------------------------
        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound($"Department with ID {id} not found.");
            }

            return Ok(department);
        }

        [HttpDelete("{id}")]//----------------------------------------------------
        public IActionResult DeleteDepartment(int id)
        {
            var deleted = _departmentService.DeleteDepartment(id);
            if (!deleted)
            {
                return NotFound($"Department with ID {id} not found.");
            }

            return NoContent(); 
        }
    }
}
