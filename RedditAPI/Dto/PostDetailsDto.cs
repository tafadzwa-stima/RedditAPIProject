namespace RedditAPI.Dto
{
    public class PostDetailsDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
    }
}
