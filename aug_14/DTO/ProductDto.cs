using System.ComponentModel.DataAnnotations;

namespace aug_14.DTO
{
    public class ProductDto
    {
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
