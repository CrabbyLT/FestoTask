using System.Collections.Generic;
using System.Threading.Tasks;
using FestoFilmaiAPI.Models;

namespace FestoFilmaiAPI.Services
{
    public interface IApiReaderService
    {
        Task<MovieModel> GetMovieOrSeriesDetailsById(string id);
        Task<List<SearchResultModel>> GetSearchResult(string searchQuery, int page, int year);
    }
}
