using aug_10.Models;
using aug_10.Repository;
using Microsoft.AspNetCore.Mvc;

namespace aug_10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public IActionResult CreateBooking(Booking booking)
        {
            var createdBooking = _bookingService.CreateBooking(booking);
            return Ok(createdBooking);
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            var bookings = _bookingService.GetBookings();
            return Ok(bookings);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetBookingById(int id)
        //{
        //    var booking = _bookingService.GetBookingById(id);
        //    return Ok(booking);
        //}
        [HttpGet("{id}")]
        public IActionResult GetBookingById(int id)
        {

            throw new ArgumentException("This is am exception from controller");
        }
    }
}