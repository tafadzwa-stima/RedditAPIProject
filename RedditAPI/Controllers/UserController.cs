using Microsoft.AspNetCore.Mvc;
using RedditAPI.Dto;
using RedditAPI.Interfaces;

namespace RedditAPI.Controllers
{
    public class UserController : Controller
    {

      private readonly IUserRepository _userRepository;

      public UserController(IUserRepository userRepository) 
      {
           _userRepository = userRepository;
      }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UsercreateDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = await _userRepository.CreateUserAsync(userDto);
            
            // Return a response with the newly created user's ID
            
            return Ok($"Successfully created + {userId}");
        }
    }
}
