using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UseCasesDependency
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IGetAllVehiclesUseCase, GetAllVehiclesUseCase>();
        }
    }
}
