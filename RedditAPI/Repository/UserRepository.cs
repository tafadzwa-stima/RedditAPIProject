using RedditAPI.Data;
using RedditAPI.Dto;
using RedditAPI.Interfaces;
using RedditAPI.Models;

namespace RedditAPI.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly RedditDataContext _dbContext;

        public UserRepository(RedditDataContext context)
        {
                _dbContext = context;
        }
        public async Task<int> CreateUserAsync(UsercreateDto userDto)
        {
            int maxUserId = _dbContext.Users.Any() ? _dbContext.Users.Max(u => u.UserId) : 0;
             int newUserId = maxUserId + 1;

            var user = new User
            {
                Username = userDto.Username
                
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return user.UserId;
        }
    }
}
