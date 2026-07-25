using System.ComponentModel.DataAnnotations;

namespace jul_22.Models
{
    public class Stationary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Name is Mandatory")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Category is Mandatory")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Brand is Mandatory")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Price is Mandatory")]
        public int Quantity { get; set; }
    }
}
