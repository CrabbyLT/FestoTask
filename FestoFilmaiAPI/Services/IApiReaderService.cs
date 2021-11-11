using System.Collections.Generic;
using System.Threading.Tasks;
using FestoFilmaiAPI.Models;

namespace FestoFilmaiAPI.Services
{
    public interface IApiReaderService
    {
        Task<MovieModel> GetMovieDetails(string id);
        Task<List<SearchResultModel>> GetSearchResult(string searchQuery, int page, int year);
    }
}
