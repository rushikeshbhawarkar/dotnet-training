using aug_10.Models;

namespace aug_10.Repository
{
    public interface IBookingService
    {
        Booking CreateBooking(Booking booking);

        List<Booking> GetBookings();

        Booking? GetBookingById(int id);
    }
}
