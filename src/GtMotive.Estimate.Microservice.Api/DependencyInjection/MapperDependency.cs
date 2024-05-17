using GtMotive.Estimate.Microservice.Api.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class MapperDependency
    {
        public static void AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(VehicleProfile));
        }
    }
}
