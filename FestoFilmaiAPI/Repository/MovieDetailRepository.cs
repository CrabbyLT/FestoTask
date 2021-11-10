using FestoFilmaiAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FestoFilmaiAPI.Repository
{
    public class MovieDetailRepository : IMovieDetailRepository
    {
        private readonly string _location;

        public MovieDetailRepository(string location)
        {
            _location = location;
            if (!File.Exists(location))
            {
                File.Create(location);
            }
        }

        public async Task<MovieModel> GetMovieFromRepository(string id)
        {
            var json = await File.ReadAllTextAsync(_location);
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }
            var parsed = GetParsed(json).FirstOrDefault(movie => movie.ImdbId == id);

            return parsed;
        }

        public async Task InsertDataToRepository(MovieModel movie)
        {
            var json = await File.ReadAllTextAsync(_location);
            var parsed = GetParsed(json) ?? new List<MovieModel>();
            parsed.Add(movie);

            await File.WriteAllTextAsync(_location, JsonConvert.SerializeObject(parsed));
        }

        private static List<MovieModel> GetParsed(string json)
        {
            return JsonConvert.DeserializeObject<List<MovieModel>>(json);
        }
    }
}
