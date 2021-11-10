using Newtonsoft.Json;

namespace FestoFilmaiAPI.Models
{
    public class MovieModel
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Year")]
        public string Year { get; set; }

        [JsonProperty("Genre")]
        public string Genre { get; set; }

        [JsonProperty("Actors")]
        public string Actors { get; set; }

        [JsonProperty("Plot")]
        public string Plot { get; set; }

        [JsonProperty("imdbRating")]
        public string ImdbRating { get; set; }
        public string ImdbId { get; set; }
    }
}
