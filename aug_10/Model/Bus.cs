using System.ComponentModel.DataAnnotations;

namespace aug_10.Models
{
    public class Bus
    {
        //Key
        public int Id { get; set; }

        [Required(ErrorMessage = "BusNumber is required")]
        [StringLength(50)]
        public string BusNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Total Seat is required")]
        [Range(1, 50)]
        public int TotalSeats { get; set; }

        [Required(ErrorMessage = "BusType is required")]
        public string BusType { get; set; } = string.Empty;
    }
}
