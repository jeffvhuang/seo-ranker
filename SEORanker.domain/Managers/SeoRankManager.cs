using SEORanker.data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEORanker.domain.Managers
{
    public class SeoRankManager : ISeoRankManager
    {
        private readonly ISearchService _service;

        public SeoRankManager(ISearchService service)
        {
            _service = service;
        }

        public async Task<List<int>> GetRanks(string search, string url)
        {
            var content = await _service.GetSearchContent(search);
            if (content == null) return null;

            var ranks = new List<int>();
            // Navigate content and get the ranks

            return ranks;
        }
    }
}
