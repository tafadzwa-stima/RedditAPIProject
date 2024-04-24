using System.ComponentModel.DataAnnotations;

namespace RedditAPI.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string? Content { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
