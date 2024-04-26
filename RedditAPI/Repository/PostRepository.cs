using Microsoft.EntityFrameworkCore;
using RedditAPI.Data;
using RedditAPI.Dto;
using RedditAPI.Interfaces;
using RedditAPI.Models;

namespace RedditAPI.Repository
{
    public class PostRepository:IPostRepository
    {
        private readonly RedditDataContext _context;

        public PostRepository(RedditDataContext context)
        {
                _context = context;
        }


        public async Task<int> CreatePostAsync(PostCreateDto postDto)
        {
            var post = new Post
            {
                Title = postDto.Title,
                Content = postDto.Content,
                CreationDate = DateTime.UtcNow,
                UserId = postDto.UserId

            };

            _context.Add(post);
            await _context.SaveChangesAsync();
            return post.PostId;
        }
               

        public async Task DeletePostAsync(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);

            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public ICollection<Post> GetPost() 
        {
            return _context.Posts.OrderBy(p=>p.PostId).ToList();
        }

        public async Task<PostDetailsDto> GetPostDetailsAsync(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);

            if (post != null)
            {
                var comments = _context.Comments
                    .Where(c => c.PostId == postId)
                    .Select(c => new CommentDto
                    {
                        CommentId = c.CommentId,
                        Content = c.Content,
                        CreationDate = c.CreationDate,
                        UserId = c.UserId
                    }).ToList();

                var votes = _context.Votes
                    .Where(v => v.PostId == postId)
                    .GroupBy(v => v.IsUpvote)
                    .Select(g => new VoteCountDto
                    {
                        IsUpvote = g.Key,
                        Count = g.Count()
                    }).ToList();

                var postDetails = new PostDetailsDto
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Content = post.Content,
                    CreationDate = post.CreationDate,
                    Comments = comments,
                    Upvotes = votes.FirstOrDefault(v => v.IsUpvote)?.Count ?? 0,
                    Downvotes = votes.FirstOrDefault(v => !v.IsUpvote)?.Count ?? 0
                };

                return postDetails;
            }

            return null;
        }

        public async Task<IEnumerable<PostDto>> GetUserPostsAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user != null)
            {
                var userPosts = _context.Posts
                    .Where(p => p.UserId == user.UserId)
                    .Select(p => new PostDto
                    {
                        PostId = p.PostId,
                        Title = p.Title,
                        Content = p.Content,
                        CreationDate = p.CreationDate
                    });

                return userPosts.ToList();
            }
            return Enumerable.Empty<PostDto>(); 
        }

        public async Task<bool> UpdatePostAsync(int postId, PostUpdateDto postDto)
        {
            var post = await _context.Posts.FindAsync(postId);

            if (post == null)
                return false;

            post.Title = postDto.Title;
            post.Content = postDto.Content;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task VotePostAsync(int postId, int userId, bool isUpvote)
        {
            var post = await _context.Posts.FindAsync(postId);
            var user = await _context.Users.FindAsync(userId);

            if (post != null && user != null)
            {
                var existingVote = _context.Votes.FirstOrDefault(v => v.PostId == postId && v.UserId == userId);

                if (existingVote != null)
                {
                    existingVote.IsUpvote = isUpvote;
                }
                else
                {
                    var vote = new Vote
                    {
                        IsUpvote = isUpvote,
                        UserId = userId,
                        PostId = postId
                    };

                    _context.Votes.Add(vote);
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
