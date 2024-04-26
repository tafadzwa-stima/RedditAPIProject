using Microsoft.AspNetCore.Mvc;
using RedditAPI.Dto;
using RedditAPI.Models;

namespace RedditAPI.Interfaces
{
    public interface IPostRepository
    {
        ICollection<Post> GetPost();

        Task<int> CreatePostAsync(PostCreateDto postDto);
        Task<bool> UpdatePostAsync(int postId, PostUpdateDto postDto);
        Task DeletePostAsync(int postId);
        Task VotePostAsync(int postId, int userId, bool isUpvote);
        Task<IEnumerable<PostDto>> GetUserPostsAsync(string username);
        Task<PostDetailsDto> GetPostDetailsAsync(int postId);
    }
}
