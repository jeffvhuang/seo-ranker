using SEORanker.data.Repositories;
using System.Collections.Generic;

namespace SEORanker.domain.Managers
{
    public class SeoRankManager : ISeoRankManager
    {
        private readonly ISearchService _service;

        public SeoRankManager(ISearchService service)
        {
            _service = service;
        }

        public List<int> GetRanks(string search, string url)
        {

        }
    }
}
