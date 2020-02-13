using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SEORanker.data.Repositories
{
    public class GoogleSearchService : ISearchService
    {
        private readonly HttpClient _client;
        private IConfigurationSection _settings;
        private readonly string _host;

        public GoogleSearchService(IConfiguration config, HttpClient client)
        {
            _client = client;
            _settings = config.GetSection("Search");
            _host = _settings["Host"];

            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("User-Agent", "SeoRanker");
        }

        public async Task<string> GetSearchContent(string search)
        {
            var url = $"{_host}/search?q={search}&num=100";
            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else if (response.StatusCode == HttpStatusCode.NotFound) return null;
            else throw new Exception(response.ReasonPhrase);
        }
    }
}
