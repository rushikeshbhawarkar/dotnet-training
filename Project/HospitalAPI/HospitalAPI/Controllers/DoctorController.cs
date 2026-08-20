using HospitalAPI.DTOs;
using HospitalAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var doctors = _service.GetAll();

            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var doctor = _service.GetById(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(DoctorDto doctorDto)
        {
            var doctor = _service.Add(doctorDto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = doctor.DoctorId },
                doctor
            );
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, DoctorDto doctorDto)
        {
            var doctor = _service.Update(id, doctorDto);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
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