using RedditAPI.Dto;

namespace RedditAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<int> CreateUserAsync(UsercreateDto userDto);

    }
}
