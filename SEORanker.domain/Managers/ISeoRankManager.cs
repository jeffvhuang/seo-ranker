using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEORanker.domain.Managers
{
    public interface ISeoRankManager
    {
        Task<List<int>> GetRanks(string search, string url);
    }
}
