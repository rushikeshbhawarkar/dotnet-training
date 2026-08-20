using System.ComponentModel.DataAnnotations;

namespace aug_17_rest.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is mandatory")]
        [StringLength(50, ErrorMessage = "Category name can be max 50 letter")]
        public string Name { get; set; } = string.Empty;
    }
}
