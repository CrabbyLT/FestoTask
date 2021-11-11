using FestoFilmaiAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FestoFilmaiAPI.Services
{
    public class ApiReaderService : IApiReaderService
    {
        private readonly HttpClient _client; 
        private readonly string URL = "http://www.omdbapi.com/";
        private readonly string URLParams = "&apikey=62d2f95";

        public ApiReaderService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(URL);
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<MovieModel> GetMovieDetails(string id)
        {

            HttpResponseMessage httpResponse = await _client.GetAsync($"?i={id}" + URLParams);
            if (httpResponse.IsSuccessStatusCode)
            {
                var json = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MovieModel>(json);
            }

            throw new Exception("not found");
        }

        public async Task<List<SearchResultModel>> GetSearchResult(string searchQuery, int page, int year)
        {
            HttpResponseMessage httpResponse;
            if (year != 0)
            {
                httpResponse = await _client.GetAsync($"?s={searchQuery}&y={year}" + URLParams);
            }
            else
            {
                httpResponse = await _client.GetAsync($"?s={searchQuery}" + URLParams);
            }

            if (httpResponse.IsSuccessStatusCode)
            {
                var json = await httpResponse.Content.ReadAsStringAsync();
                var parsed = JsonConvert.DeserializeObject<OmdbSearchModel>(json);

                return parsed.Search;
            }

            throw new Exception("not found");
        }
    }
}
