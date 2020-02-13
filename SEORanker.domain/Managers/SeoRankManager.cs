using SEORanker.data.Repositories;
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

        public async Task<string> GetSearchContent(string search)
        {
            var content = await _service.GetSearchContent(search);
            return content;
        }
    }
}
