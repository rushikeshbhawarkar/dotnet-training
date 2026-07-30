using jul_29.Model;
using jul_29.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jul_29.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: api/Vehicle
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_vehicleService.GetVehicles());
        }

        // GET: api/Vehicle/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var vehicle = _vehicleService.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound($"Vehicle with ID {id} not found.");
            }

            return Ok(vehicle);
        }

        // POST: api/Vehicle
        [HttpPost]
        public IActionResult Create(Vehicle vehicle)
        {
            var createdVehicle = _vehicleService.AddVehicle(vehicle);
            return Ok(createdVehicle);
        }

        // PUT: api/Vehicle/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, Vehicle vehicle)
        {
            var isUpdated = _vehicleService.UpdateVehicle(id, vehicle);
            if (!isUpdated)
            {
                return NotFound($"Vehicle with ID {id} not found.");
            }

            return Ok("Vehicle updated successfully.");
        }
    }
}
