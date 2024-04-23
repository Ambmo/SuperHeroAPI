using Microsoft.AspNetCore.Mvc;
using SuperheroAPI.Services.Interfaces;

namespace SuperheroAPI.Controllers
{
    /// <summary>
    /// Controller for managing user data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="username">The username of the new user.</param>
        /// <returns>Returns the newly created user.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser(string username)
        {
            try
            {
                var newUser = await _userService.CreateUser(username);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get a user by ID.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        /// <returns>Returns the user with the specified ID.</returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            try
            {
                var user = await _userService.GetUserById(userId);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
