using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.Inputs;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UseCasesDependency
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IGetAllVehiclesUseCase, GetAllVehiclesUseCase>();
            services.AddScoped<ICreateVehicleUseCase<VehicleInput>, CreateVehicleUseCase>();
            services.AddScoped<IRentVehicleUseCase<RentVehicleInput>, RentVehicleUseCase>();
            services.AddScoped<IReturnVehicleUseCase<ReturnVehicleInput>, ReturnVehicleUseCase>();
        }
    }
}
