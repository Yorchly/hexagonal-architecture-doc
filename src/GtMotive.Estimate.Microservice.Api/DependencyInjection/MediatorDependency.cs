using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class MediatorDependency
    {
        public static void AddMediator(this IServiceCollection services) =>
            services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}
