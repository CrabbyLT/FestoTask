using FestoFilmaiAPI.Models;
using System.Threading.Tasks;

namespace FestoFilmaiAPI.Repository
{
    public interface IMovieDetailRepository
    {
        Task InsertDataToRepository(MovieModel movie);
        Task<MovieModel> GetMovieFromRepository(string id);
    }
}
