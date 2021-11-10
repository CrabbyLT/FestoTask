using FestoFilmaiAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FestoFilmaiAPI.Repository
{
    public interface IMovieSearchRepository
    {
        Task InsertSearchResultsToRepositoryAsync(List<SearchResultModel> searchResults);
        Task<IEnumerable<SearchResultModel>> GetSearchResultModels(string searchQuery, int page);
    }
}
