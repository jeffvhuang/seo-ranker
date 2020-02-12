using Microsoft.Extensions.DependencyInjection;
using SEORanker.data.Repositories;

namespace SEORanker.domain.Frameworks
{
    public class ServiceManager
    {
        public static void InjectServices(IServiceCollection services)
        {
            services.AddHttpClient<ISearchService, GoogleSearchService>();
        }
    }
}
