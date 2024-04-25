using System.ComponentModel.DataAnnotations;

namespace RedditAPI.Models
{
    public class Vote
    {
        public int VoteId { get; set; }
        public bool IsUpvote { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? PostId { get; set; }
        public Post Post { get; set; }
        public int? CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
