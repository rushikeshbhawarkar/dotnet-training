using HospitalAPI.DTOs;
using HospitalAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Doctor")]
        public IActionResult GetAll()
        {
            var patients = _service.GetAll();

            return Ok(patients);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Doctor")]
        public IActionResult GetById(int id)
        {
            var patient = _service.GetById(id);

            return Ok(patient);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Doctor")]
        public IActionResult Add(PatientDto patientDto)
        {
            var result = _service.Add(patientDto);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Doctor")]
        public IActionResult Update(
            int id,
            PatientDto patientDto)
        {
            var result = _service.Update(id, patientDto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Doctor")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);

            return Ok("Patient deleted successfully.");
        }
    }
}