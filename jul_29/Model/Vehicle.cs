using System.ComponentModel.DataAnnotations;

namespace jul_29.Model
{
    public class Vehicle
    {
    
            public int Id { get; set; }

            [Required(ErrorMessage = "Name is required")]
            public string Name { get; set; }

            [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
            public decimal Price { get; set; }

            [Required(ErrorMessage = "Type is required")]
            public string Type { get; set; }

            [Required(ErrorMessage = "Brand is required")]
            public string Brand { get; set; }
        }
    }

