using FestoFilmaiAPI.Models;
using FestoFilmaiAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FestoFilmaiAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet("{movieName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SearchResultModel>))]
        public async Task<IActionResult> GetMoviesSorted(string movieName, [FromQuery] int page = 1)
        {
            var sortedMoviesList = await _moviesService.GetMoviesSorted(movieName, page);

            return Ok(sortedMoviesList);
        }

        [HttpGet("Movie/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieModel))]
        public async Task<IActionResult> GetMovieDetails(string id)
        {
            var movieDetail = await _moviesService.GetDetailsFromId(id);

            return Ok(movieDetail);
        }
    }
}
