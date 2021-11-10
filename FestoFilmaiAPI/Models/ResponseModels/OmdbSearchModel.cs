using Newtonsoft.Json;
using System.Collections.Generic;

namespace FestoFilmaiAPI.Models
{
    public class OmdbSearchModel
    {
        [JsonProperty("Search")]
        public List<SearchResultModel> Search { get; set; }

        [JsonProperty("totalResults")]
        public string TotalResults { get; set; }

        [JsonProperty("Response")]
        public string Response { get; set; }
    }
}
