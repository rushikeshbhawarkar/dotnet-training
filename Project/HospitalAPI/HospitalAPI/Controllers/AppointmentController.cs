using HospitalAPI.DTOs;
using HospitalAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin,Doctor")]
        public IActionResult GetAll()
        {
            var appointments = _service.GetAll();

            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var appointment = _service.GetById(id);

            return Ok(appointment);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Doctor")]
        public IActionResult Add(AppointmentDto appointmentDto)
        {
            var appointment = _service.Add(appointmentDto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = appointment.AppointmentId },
                appointment
            );
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Doctor")]
        public IActionResult Update(
            int id,
            AppointmentDto appointmentDto)
        {
            var appointment = _service.Update(id, appointmentDto);

            return Ok(appointment);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Doctor")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);

            return NoContent();
        }
    }
}