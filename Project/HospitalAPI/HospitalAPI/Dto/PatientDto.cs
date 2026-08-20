using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.DTOs
{
    public class PatientDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Mandatory")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name length is between 3 to max 30")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "DateOfBirth is Mandatory")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is Mandatory")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Email is Mandatory")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone is Mandatory")]
        [Phone(ErrorMessage = "Phone is Invalid")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Address is Mandatory")]
        public string? Address { get; set; }
    }
}