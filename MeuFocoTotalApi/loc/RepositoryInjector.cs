using MeuFocoTotalApi.Repository;

namespace MeuFocoTotalApi.Ioc
{
    public class RepositoryInjector
    {
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IFocoTotalRepository, FocoTotalRepository>();
        }
    }
}
