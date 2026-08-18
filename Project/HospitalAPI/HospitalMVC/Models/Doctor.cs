using System.ComponentModel.DataAnnotations;

namespace HospitalMVC.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "DoctorName is Required")]
        [StringLength(50, ErrorMessage = "Name length is Max 50")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Specialization is Required")]
        [StringLength(50, ErrorMessage = "Specialization length is Max 50")]
        public string? Specialization { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Email is Mandatory")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone is Required")]
        [Phone(ErrorMessage = "PhoneNo is Invalid")]
        public string? Phone { get; set; }

        public int DepartmentId { get; set; }
    }
}