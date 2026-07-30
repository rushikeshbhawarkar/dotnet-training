using System.ComponentModel.DataAnnotations;

namespace jul_27.Model
{
    public class Employee
    {
        [Required(ErrorMessage = "Emp Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Emp Name is required")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Must be atkeast 3 letters")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Emp LastName is required")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Emp Department is required")]
        [StringLength(25, ErrorMessage = "Dept  cannot be more than 25 letters")]
        public string Dept { get; set; }
        [Required(ErrorMessage = "Emp Phone Number is required")]
        public long PhoneNum { get; set; }
        public string Profile { get; set; }
        public string Location { get; set; }
    }
}
