using System.Collections.Generic;
using System.Threading.Tasks;
using FestoFilmaiAPI.Models;

namespace FestoFilmaiAPI.Services
{
    public interface IMoviesService
    {
        Task<IEnumerable<SearchResultModel>> GetMoviesSorted(string movieName, int page, int year);
        Task<MovieModel> GetDetailsFromId(string id);
    }
}
