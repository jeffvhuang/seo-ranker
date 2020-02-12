using System.Collections.Generic;

namespace SEORanker.domain.Managers
{
    public interface ISeoRankManager
    {
        List<int> GetRanks(string search, string url);
    }
}
