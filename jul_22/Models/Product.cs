using System.ComponentModel.DataAnnotations;

namespace jul_22.Models
{
    public class Product
    {
        public int Id {  get; set; }
        [Required(ErrorMessage = "Name is Mandatory")]
        public string Name {  get; set; }
        [Required(ErrorMessage = "Price is Mandatory")]
        public int Price {  get; set; }
        [Required(ErrorMessage = "Category is Mandatory")]
        public string Category {  get; set; }
        [Required(ErrorMessage = "Stock is Mandatory")]
        public int Stock {  get; set; } 

    }
}
