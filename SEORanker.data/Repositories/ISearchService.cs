using System.Threading.Tasks;

namespace SEORanker.data.Repositories
{
    public interface ISearchService
    {
        Task<string> GetSearchContent(string search);
    }
}
