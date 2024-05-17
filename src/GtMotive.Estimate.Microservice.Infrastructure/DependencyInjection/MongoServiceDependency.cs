using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Infrastructure.DependencyInjection
{
    public static class MongoServiceDependency
    {
        public static void AddMongoService(this IServiceCollection services) =>
            services.AddSingleton<MongoService>();
    }
}
