//using aug_17_rest.Model;
//using aug_17_rest.Repository;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace aug_17_rest.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrderController : ControllerBase
//    {
//        private readonly IOrderService service;

//        public OrderController(IOrderService service)
//        {
//            this.service = service;
//        }

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var orders = service.GetOrders();
//            return Ok(orders);
//        }
//    }
//}
