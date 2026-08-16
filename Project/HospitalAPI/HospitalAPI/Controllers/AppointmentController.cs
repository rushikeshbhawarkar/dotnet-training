using HospitalAPI.DTOs;
using HospitalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        // GET: api/Appointment
        [HttpGet]
        public IActionResult GetAll()
        {
            var appointments = _service.GetAll();

            return Ok(appointments);
        }

        // GET: api/Appointment/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var appointment = _service.GetById(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        // POST: api/Appointment
        [HttpPost]
        public IActionResult Add(AppointmentDto appointmentDto)
        {
            var appointment = _service.Add(appointmentDto);

            return Ok(appointment);
        }

        // PUT: api/Appointment/5
        [HttpPut("{id}")]
        public IActionResult Update(
            int id,
            AppointmentDto appointmentDto)
        {
            var appointment = _service.Update(id, appointmentDto);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        // DELETE: api/Appointment/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok("Appointment deleted successfully.");
        }
    }
}