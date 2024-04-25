using System.ComponentModel.DataAnnotations;

namespace RedditAPI.Models
{

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Vote> Votes { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
