using assignment_06.Models;
using assignment_06.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment_06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService service;

        public OrderController(IOrderService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetOrders());
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = service.GetOrderById(id);
            if (order == null)
            {
                return NotFound("Order not available");
            }

            return Ok(order);
        }
    }
}