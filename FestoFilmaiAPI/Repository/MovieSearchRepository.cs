using FestoFilmaiAPI.Models;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace FestoFilmaiAPI.Repository
{
    public class MovieSearchRepository : IMovieSearchRepository
    {
        private readonly string _location;

        public MovieSearchRepository(string location)
        {
            _location = location;
            if (!File.Exists(location))
            {
                File.Create(location);
            }
        }

        public async Task<IEnumerable<SearchResultModel>> GetSearchResultModels(string searchQuery, int page)
        {
            var json = await File.ReadAllTextAsync(_location);
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }
            var parsed = GetParsed(json).Where(movie => movie.Title.ToLowerInvariant().Contains(searchQuery)).Take(10 * page);

            return parsed;
        }

        public async Task InsertSearchResultsToRepositoryAsync(List<SearchResultModel> searchResults)
        {
            var json = await File.ReadAllTextAsync(_location);
            var parsed = GetParsed(json) ?? new List<SearchResultModel>();

            foreach (var item in searchResults)
            {
                if (!parsed.Contains(item))
                {
                    parsed.Add(item);
                }
            }

            await File.WriteAllTextAsync(_location, JsonConvert.SerializeObject(parsed));
        }

        private static List<SearchResultModel> GetParsed(string json)
        {
            return JsonConvert.DeserializeObject<List<SearchResultModel>>(json);
        }
    }
}
