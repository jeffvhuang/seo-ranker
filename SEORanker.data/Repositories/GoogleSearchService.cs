using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SEORanker.data.Repositories
{
    public class GoogleSearchService : ISearchService
    {
        private readonly HttpClient _client;
        private IConfigurationSection _settings;

        public GoogleSearchService(IConfiguration config, HttpClient client)
        {

        }

        public string GetSearchContent(string search)
        {

        }
    }
}
