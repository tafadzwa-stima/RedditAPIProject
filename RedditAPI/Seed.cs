using RedditAPI.Data;
using RedditAPI.Models;

namespace RedditAPI
{
    public class Seed
    {
        private readonly RedditDataContext _dbContext;

        public Seed(RedditDataContext dbContext)
        {
            _dbContext = dbContext;
        }


        public  void SeedData()
        {
            // Seed Users
            if (!_dbContext.Users.Any())
            {
                var users = new[]
                {
                    new User { Username = "user1", UserId= 12 },
                    new User { Username = "user2", UserId = 34 },
                    
                };

                _dbContext.Users.AddRange(users);
                _dbContext.SaveChanges();
            }

            // Seed Posts
            if (!_dbContext.Posts.Any())
            {
                var posts = new[]
                {
                    new Post { Title = "Post 1", Content = "Content of Post 1", CreationDate = DateTime.UtcNow, UserId = 1 },
                    new Post { Title = "Post 2", Content = "Content of Post 2", CreationDate = DateTime.UtcNow, UserId = 2 },
                    
                };

                _dbContext.Posts.AddRange(posts);
                _dbContext.SaveChanges();
            }

            // Seed Comments
            if (!_dbContext.Comments.Any())
            {
                var comments = new[]
                {
                    new Comment { Content = "Comment 1 on Post 1", CreationDate = DateTime.UtcNow, UserId = 1, PostId = 1 },
                    new Comment { Content = "Comment 2 on Post 1", CreationDate = DateTime.UtcNow, UserId = 2, PostId = 1 },
                    
                };

                _dbContext.Comments.AddRange(comments);
                _dbContext.SaveChanges();
            }

            
            if (!_dbContext.Votes.Any())
            {
                var votes = new[]
                {
                    new Vote { IsUpvote = true, UserId = 1, PostId = 1 },
                    new Vote { IsUpvote = false, UserId = 2, PostId = 1 },
                   
                };

                _dbContext.Votes.AddRange(votes);
                _dbContext.SaveChanges();
            }
        }
    }
}
