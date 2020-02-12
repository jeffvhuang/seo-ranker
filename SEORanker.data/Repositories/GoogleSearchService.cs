using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SEORanker.data.Repositories
{
    public class GoogleSearchService : ISearchService
    {
        private readonly HttpClient _client;
        private IConfigurationSection _settings;

        public GoogleSearchService(IConfiguration config, HttpClient client)
        {
            _client = client;
            _settings = config.GetSection("Search");
            var host = _settings["Host"];

            _client.BaseAddress = new Uri(host);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("User-Agent", "SeoRanker");
        }

        public async Task<string> GetSearchContent(string search)
        {
            var searchQuery = search.Replace(" ", "%20");
            var path = $"/search?q={searchQuery}";
            var response = await _client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<string>(jsonString);
                return result;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound) return null;
            else throw new Exception(response.ReasonPhrase);
        }
    }
}
