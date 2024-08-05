
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuikQuest.Models
{
    public class Cart
    {
        public Cart() {

            Products = new List<Product>();

        }
        public Cart(string UI)
        {
            UserId = UI;
            Products = new List<Product>();
        }

        [Key]
        public int CartId { get; set; }

       
        public List<Product> Products { get; set; }

        [Required]
        public string UserId { get; set; }


    }
}
