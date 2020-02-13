using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEORanker.domain.Managers
{
    public interface ISeoRankManager
    {
        Task<string> GetSearchContent(string search);
    }
}
