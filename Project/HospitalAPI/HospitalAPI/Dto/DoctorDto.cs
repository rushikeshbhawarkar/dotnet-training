using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.DTOs
{
    public class DoctorDto
    {
        [Required(ErrorMessage = " DoctorName is Required")]
        [StringLength(50,ErrorMessage ="Name length is Max 50")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Specialization is Required")]
        [StringLength(50,ErrorMessage="Specilazation length is Max 50")]

        public string? Specialization { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress( ErrorMessage = "Email is  Mandatory ")]

        public string? Email { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [Phone(ErrorMessage = "PhoneNo is Invalid")]

        public string? Phone { get; set; }
        // tu kar tera mai aata bahar se kaam khatam ki session band kar dena
        //ok kitta baaje ayanga afte 45 min ok thik hai//ok thi hai //
        public int DepartmentId { get; set; }
    }
}