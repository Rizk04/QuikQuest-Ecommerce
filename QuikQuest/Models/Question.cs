using System.ComponentModel.DataAnnotations;

namespace QuikQuest.Models
{
    public class Question
    {
        
        [Key]
        public int QuestionId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string QuestionDetails { get; set; }

        public string UserId { get; set; }
    }
}
