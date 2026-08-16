using HospitalAPI.DTOs;
using HospitalAPI.Services;
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
        public IActionResult GetAll()
        {
            var patients = _service.GetAll();

            return Ok(patients);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var patient = _service.GetById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpPost]
        public IActionResult Add(PatientDto patientDto)
        {
            var result = _service.Add(patientDto);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PatientDto patientDto)
        {
            var result = _service.Update(id, patientDto);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok("Patient deleted successfully.");
        }
    }
}