using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Model
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Doctor Name is Required")]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "Max Length of Doctor Name is in between 3 to 50")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Specialization is Required")]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "Specialization length is between 3 to 50")]
        public string? Specialization { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone is Required")]
        [Phone(ErrorMessage = "Phone No is Invalid")]
        public string? Phone { get; set; }

        //------------------------
        // Foreign Key
        public int DepartmentId { get; set; }

        // Navigation Property
        public Department? Department { get; set; }

        // One Doctor → Many Appointments
        public ICollection<Appointment>? Appointments { get; set; }
    }
}