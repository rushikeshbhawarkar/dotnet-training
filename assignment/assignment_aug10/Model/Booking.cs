namespace assignment_aug10.Model
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public Customer? Customer { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}
