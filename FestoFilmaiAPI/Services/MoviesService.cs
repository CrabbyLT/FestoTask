using FestoFilmaiAPI.Models;
using System.Threading.Tasks;
using FestoFilmaiAPI.Repository;
using System.Collections.Generic;
using System.Linq;

namespace FestoFilmaiAPI.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IApiReaderService _apiReaderService;
        private readonly IMovieSearchRepository _movieSearchRepository;
        private readonly IMovieDetailRepository _movieDetailRepository;

        public MoviesService(IApiReaderService apiReaderService, IMovieSearchRepository movieSearchRepository, IMovieDetailRepository movieDetailRepository) : this(apiReaderService)
        {
            _movieSearchRepository = movieSearchRepository;
            _movieDetailRepository = movieDetailRepository;
        }

        public MoviesService(IApiReaderService apiReaderService)
        {
            _apiReaderService = apiReaderService;

        }

        public async Task<MovieModel> GetDetailsFromId(string id)
        {
            var result = await _movieDetailRepository.GetMovieFromRepository(id);
            if (result is null)
            {
                result = await _apiReaderService.GetMovieOrSeriesDetailsById(id);
                await _movieDetailRepository.InsertDataToRepository(result);
            }

            return result;
        }

        public async Task<IEnumerable<SearchResultModel>> GetMoviesSorted(string searchQuery, int page, int year)
        {
            var result = await _movieSearchRepository.GetSearchResultModels(searchQuery, page);
            if (!result.Any())
            {
                result = await _apiReaderService.GetSearchResult(searchQuery, page, year);
                if (result is not null)
                {
                    await _movieSearchRepository.InsertSearchResultsToRepositoryAsync((List<SearchResultModel>)result);
                }
            }

            return result;
        }
    }
}
