using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Infrastructure.DependencyInjection
{
    public static class RepositoriesDependency
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IVehicleRepository, VehicleRepository>();
        }
    }
}
