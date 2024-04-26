using Microsoft.AspNetCore.Mvc;
using RedditAPI.Dto;
using RedditAPI.Interfaces;
using RedditAPI.Models;

namespace RedditAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Post))]

        public IActionResult GetPost() 
        {
            var post = _postRepository.GetPost();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostCreateDto postDto)
        {
            var result = await _postRepository.CreatePostAsync(postDto);
            return Ok(result);
        }

        [HttpPut("{postId}")]
        public async Task<IActionResult> UpdatePost(int postId, PostUpdateDto postDto)
        {
            var result = await _postRepository.UpdatePostAsync(postId, postDto);
            return Ok(result);
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            await _postRepository.DeletePostAsync(postId);
            return NoContent();
        }

        [HttpPost("{postId}/upvote")]
        public async Task<IActionResult> UpvotePost(int postId, int userId)
        {
            await _postRepository.VotePostAsync(postId, userId, true);
            return NoContent();
        }

        [HttpPost("{postId}/downvote")]
        public async Task<IActionResult> DownvotePost(int postId, int userId)
        {
            await _postRepository.VotePostAsync(postId, userId, false);
            return NoContent();
        }

        [HttpGet("user/{username}")]
        public async Task<IActionResult> GetUserPosts(string username)
        {
            var result = await _postRepository.GetUserPostsAsync(username);
            return Ok(result);
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostDetails(int postId)
        {
            var result = await _postRepository.GetPostDetailsAsync(postId);
            return Ok(result);
        }
    }
}
