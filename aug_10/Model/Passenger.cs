using System.ComponentModel.DataAnnotations;

namespace aug_10.Models
{
    public class Passenger
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Number is not correct")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Email id is required")]
        [EmailAddress(ErrorMessage = "Email id is not valid")]
        public string? Email { get; set; }
    }
}
