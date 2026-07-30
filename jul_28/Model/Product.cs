using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace jul_28.Model
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, MinimumLength =5, ErrorMessage ="Product name must be between 5 to 100 letters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Product Price is required")]
        [Range(10,100000, ErrorMessage ="Product Price must be between 10 to 100000 ")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Product Quantity is required")]
        [Range(1, 100, ErrorMessage = "Minimum Quantity = 1 , Maximun Quantity = 100")]
        public int Quantity { get; set; }
    }
}
