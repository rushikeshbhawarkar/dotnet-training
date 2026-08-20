using System.ComponentModel.DataAnnotations;
namespace HospitalAPI.Model
{
    public class Patient
    {
        public int PatientId { get; set; }

        [Required(ErrorMessage="Patient Name is Required")]
        [StringLength(50,MinimumLength = 3 ,ErrorMessage= " Max Length of Patient Name is in between 3 to 50")]

        public string? Name { get; set; }

        [Required(ErrorMessage = "DateOfBirth is Required")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Gender is Required")]

        public string? Gender { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        [EmailAddress(ErrorMessage= "Invalid Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone is Required")]
        [Phone(ErrorMessage="Phone No is Invalid")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [StringLength( 50 , MinimumLength= 3,ErrorMessage="Address length is between 3 to 50")]

        public string? Address { get; set; }

        // Relationship:
        // One Patient → Many Appointments
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
