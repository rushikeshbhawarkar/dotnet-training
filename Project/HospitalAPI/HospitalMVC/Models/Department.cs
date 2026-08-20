using System.ComponentModel.DataAnnotations;

namespace aug_17_mvc.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department Name is Required")]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "Max Length of Department Name is in between 3 to 50")]
        public string? DepartmentName { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Description length is between 3 to 100")]
        public string? Description { get; set; }
    }
}