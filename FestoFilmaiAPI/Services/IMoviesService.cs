using System.Collections.Generic;
using System.Threading.Tasks;
using FestoFilmaiAPI.Models;

namespace FestoFilmaiAPI.Services
{
    public interface IMoviesService
    {
        Task<IEnumerable<SearchResultModel>> GetMoviesSorted(string movieName, int page);
        Task<MovieModel> GetDetailsFromId(string id);
    }
}
