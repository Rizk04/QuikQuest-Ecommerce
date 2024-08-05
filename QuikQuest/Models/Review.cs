using System.ComponentModel.DataAnnotations;

namespace QuikQuest.Models
{
    public class Review
    {
       
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Rating { get; set; }
        public string UserId { get; set; }
    }
}
