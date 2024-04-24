using RedditAPI.Data;
using RedditAPI.Models;

namespace RedditAPI
{
    public class Seed
    {
        private readonly DataContext _dataContext;

        public Seed(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public void SeedDataContext() 
        {
            if (_dataContext.Users.Any() || _dataContext.Posts.Any() ||_dataContext.Comments.Any()) 
            {
                // Data already exists, no need to seed
                return;

            }

            var users = new[]
            {
                 new User { UserName = "user1", PasswordHash = "hashedpassword1" },
                new User { UserName = "user2", PasswordHash = "hashedpassword2" }
            };
            _dataContext.Users.AddRange(users);
            _dataContext.SaveChanges();


            var posts = new[]
            {
                new Post {  Title = "Post 1", Content = "Content of post 1", UserId = users[0].Id },
                new Post { Title = "Post 2", Content = "Content of post 2", UserId = users[1].Id }

            };
            _dataContext.Posts.AddRange(posts);
            _dataContext.SaveChanges();

            var comments = new[]
            {
                new Comment { Content = "Comment 1 on post 1", UserId = users[0].Id, PostId = posts[0].Id },
                new Comment { Content = "Comment 2 on post 1", UserId = users[1].Id, PostId = posts[0].Id },
                new Comment { Content = "Comment 1 on post 2", UserId = users[0].Id, PostId = posts[1].Id }
            };
            _dataContext.Comments.AddRange(comments);
            _dataContext.SaveChanges();

        }

    }
}
