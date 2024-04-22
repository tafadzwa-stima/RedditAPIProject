namespace RedditAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public int UserName { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
