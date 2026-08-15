using aug_14.DTO;
using aug_14.Models;
using aug_14.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aug_14.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            service.GetCustomer();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var cust = service.GetCustomerById(id);
            if (cust == null)
            {
                return NotFound();
            }
            return Ok(cust);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
             service.Add(customer);
            return Ok();
        }

       
        
    }
}
