using System.ComponentModel.DataAnnotations;

namespace aug_17_mvc.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Appointment Date is Required")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Status is Required")]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "Status length is between 3 to 50")]
        public string? Status { get; set; }

        [Required(ErrorMessage = "Reason is Required")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Reason length is between 3 to 100")]
        public string? Reason { get; set; }

        public int PatientId { get; set; }

        public string? PatientName { get; set; }

        public int DoctorId { get; set; }

        public string? DoctorName { get; set; }
    }
}