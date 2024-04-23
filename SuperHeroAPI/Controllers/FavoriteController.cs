using Microsoft.AspNetCore.Mvc;
using SuperheroAPI.Services.Interfaces;
using SuperHeroAPI.Models;

namespace SuperheroAPI.Controllers
{
    /// <summary>
    /// Controller for managing Favorite Characters into SQL lite DB.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FavoriteController"/> class.
        /// </summary>
        /// <param name="favoriteService">The favorite service.</param>
        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        /// <summary>
        /// Add Favorite Character into DB with attached SuperheroId, UserId
        /// </summary>
        /// <param name="favorite">The favorite model.</param>
        /// <returns>Return the added model.</returns>
        [HttpPost]
        public async Task<IActionResult> AddFavorite([FromBody] Favorite favorite)
        {
            try
            {
                await _favoriteService.AddFavorite(favorite);
                return Ok(favorite);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get all favorite characters.
        /// </summary>
        /// <returns>Returns all favorite characters.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllFavorites()
        {
            try
            {
                var favorites = await _favoriteService.GetFavorites();
                return Ok(favorites);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get favorite characters by user ID.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <returns>Returns favorite characters by user ID.</returns>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetFavoritesByUserId(string userId)
        {
            try
            {
                var favorites = await _favoriteService.GetFavoritesByUserId(userId);
                return Ok(favorites);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
