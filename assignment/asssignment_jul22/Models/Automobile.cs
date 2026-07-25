using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class Automobile
    {
        [Required(ErrorMessage = "Vehicle ID is required.")]
        [Display(Name = "Vehicle ID")]
        public string VehicleId { get; set; }

        [Required(ErrorMessage = "Vehicle Name is required.")]
        [StringLength(100, ErrorMessage = "Vehicle Name cannot exceed 100 characters.")]
        [Display(Name = "Vehicle Name")]
        public string VehicleName { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        [StringLength(50, ErrorMessage = "Brand cannot exceed 50 characters.")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model Year is required.")]
        [Range(1900, 2030, ErrorMessage = "Model Year must be between 1900 and 2030.")]
        [Display(Name = "Model Year")]
        public int ModelYear { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0, 10000000, ErrorMessage = "Price must be between 0 and 10,000,000.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Fuel Type is required.")]
        [StringLength(50, ErrorMessage = "Fuel Type cannot exceed 50 characters.")]
        [Display(Name = "Fuel Type")]
        public string FuelType { get; set; }
    }
}