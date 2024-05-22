using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class ApiDependency
    {
        public static void AddAllApiDependencies(this IServiceCollection services)
        {
            services.AddMappers();
            services.AddMediator();
            services.AddUseCases();
            services.AddPresenters();
        }
    }
}
