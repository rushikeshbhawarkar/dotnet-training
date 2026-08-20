using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Model
{
    public class AppointmentHistory
    {
        public int AppointmentHistoryId { get; set; }

        [Required(ErrorMessage = "Status is Required")]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "Status length is between 3 to 50")]
        public string? Status { get; set; }

        [Required(ErrorMessage = "ChangedAt is Required")]
        public DateTime ChangedAt { get; set; }

        [Required(ErrorMessage = "Remarks is Required")]
        [StringLength(100, MinimumLength = 1,
            ErrorMessage = "Remarks length is between 1 to 100")]
        public string? Remarks { get; set; }

        // Foreign Key
        public int AppointmentId { get; set; }

        // Navigation Property
        public Appointment? Appointment { get; set; }
    }
}