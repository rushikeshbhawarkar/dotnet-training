using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Model
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

        // Relationships

        // Patient relationship
        // One Patient → Many Appointments
        public int PatientId { get; set; }

        public Patient? Patient { get; set; }


        // Doctor relationship
        // One Doctor → Many Appointments
        public int DoctorId { get; set; }

        public Doctor? Doctor { get; set; }


        // Appointment History relationship
        // One Appointment → Many History Records
        public ICollection<AppointmentHistory>? AppointmentHistories { get; set; }
    }
}