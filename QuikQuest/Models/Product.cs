using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuikQuest.Models
{
    public class Product

    {

        public Product() { 
        
        Carts = new List<Cart>();
        }
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MinLength(1), MaxLength(60)]
        public string Name { get; set; }
        [Display(Name = "Condition")]

        public string ProductType { get; set; } = "";
        [Required]
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        [Range(0.0, 9999.99, ErrorMessage = "The value must be between 0 and 9999.99")]
        public float Price { get; set; } = 0;

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImgURL { get; set; }

        public List<Cart> Carts { get; set; }
    }
}
