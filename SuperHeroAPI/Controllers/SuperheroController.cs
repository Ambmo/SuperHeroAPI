using Microsoft.AspNetCore.Mvc;
using SuperheroAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperheroAPI.Controllers
{
    /// <summary>
    /// Controller for managing superheroes.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SuperheroController : ControllerBase
    {
        private readonly SuperheroService _superheroService;

        public SuperheroController(SuperheroService superheroService)
        {
            _superheroService = superheroService;
        }

        /// <summary>
        /// Retrieves information about a superhero with the specified ID.
        /// </summary>
        /// <param name="superheroId">The ID of the superhero to retrieve.</param>
        /// <returns>Information about the specified superhero.</returns>
        [HttpGet("{superheroId}")]
        public async Task<IActionResult> GetSuperheroInfo(int superheroId)
        {
            try
            {
                var superheroInfo = await _superheroService.GetSuperheroById(superheroId);
                return Ok(superheroInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        //[HttpPost("favorites")]
        //public async Task<IActionResult> GetFavoriteSuperheroes([FromBody] List<int> superheroIds)
        //{
        //    try
        //    {
        //        var favoriteSuperheroes = await _superheroService.GetFavoriteSuperheroes(superheroIds);
        //        return Ok(favoriteSuperheroes);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"An error occurred: {ex.Message}");
        //    }
        //}
    }
}
